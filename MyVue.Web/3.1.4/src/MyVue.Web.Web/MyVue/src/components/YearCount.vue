<template>
  <div>
    <div id="ChartLine" class="chart"></div>
    <div id="ChartPie" class="chart"></div>
  </div>
</template>
<script>
  import { Toast } from 'mint-ui';
  // 按需引入echart模板
  let echarts = require('echarts/lib/echarts');
  require('echarts/lib/chart/pie');
  require('echarts/lib/chart/line');
  require('echarts/lib/component/tooltip');
  require('echarts/lib/component/title');

  export default{
    data(){
      return{
        LineData:[],//曲线图数据
        PieData:[],// 饼图数据
        date:new Date(), // 时间
      }
    },
    methods:{
      // 获取曲线图数据
      GetChartLineData(){
        this.$http.post('/bill/GetCount', {
          Date: this.date,
          Type:0,
          GroupBy:1,
          User: '1'
        }).then(response => {
          if(response.body.result.result)
          {
            this.LineData = response.body.result.data;
          }else
          {
            Toast(response.body.result.data)
          }
        }, response => {
          Toast("获取数据出错");
        });
      },
      // 获取饼图数据
      GetPieData(){
        this.$http.post('/bill/GetCount', {
          Date:this.date,
          Type:0,
          User: '1',
        }).then(response => {
          if(response.body.result.result)
          {
            this.PieData = response.body.result.data;
          }else
          {
            Toast(response.body.result.data)
          }
        }, response => {
          Toast("获取数据出错");
        });
      },
      // 绘制图表
      DrawPieChart(){
        // 基于准备好的dom，初始化echarts实例
        let myChart = echarts.init(document.getElementById('ChartPie'));
        let data = this.PieData;
        // 绘制图表
        myChart.setOption({
          tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
          },
          series: [
            {
              name: '消费',
              type: 'pie',
              radius: '55%',
              center: ['50%', '50%'],
              data: data
            }
          ]
        });
      },
      DrawLineChart(){
        // 基于准备好的dom，初始化echarts实例
        let myChart = echarts.init(document.getElementById('ChartLine'));
        let data = this.LineData;
        let x=[],y=[],count=0;
        for(let i of data)
        {
          x.push(i.name);
          y.push(i.value);
          count+=i.value;
        }
        // 绘制图表
        myChart.setOption({
          title : {
            text: count,
            subtext: '单位（元）',
            x:'right'
          },
          tooltip: {
            trigger: 'axis'
          },
          calculable: false,
          grid: { x: 12, y: 10, x2: 12, y2: 30, borderWidth: 0 },
          xAxis: [
            {
              splitLine: { show: false },
              type: 'category',
              boundaryGap: false,
              data: x
            }
          ],
          yAxis: [
            {
              show: false,
              type: 'value'
            }
          ],
          series: [
            {
              name: '消费',
              type: 'line',
              center: ['10%', '10%'],
              smooth: true,
              itemStyle: { normal: { areaStyle: { type: 'default' } } },
              data: y
            },


          ]
        });
      }
    },
    // 监测变化
    watch:{
      PieData:function () {
        this.DrawPieChart(); // 绘制表格

      },
      LineData:function () {
        this.DrawLineChart(); // 绘制表格

      }
    },
    // 创建后执行
    mounted(){
      this.GetChartLineData();
      this.GetPieData();
    }
  }
</script>
<style scoped>
  .chart{
    width: 100%;
    height: 300px;
  }

</style>
