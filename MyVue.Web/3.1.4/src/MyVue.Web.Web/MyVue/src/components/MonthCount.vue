<template>
  <div id="MonthCount" >
    <div class="chart">
      <div id="Chart"></div>
    </div>
    <ul class="list">
      <li v-for="item in listData">
        <mt-cell-swipe v-bind:title="item.name" v-bind:label="item.creationTime" :right="[{
                                                                                                      content: '删除',
                                                                                                      style: { background: 'red', color: '#fff' },
                                                                                                      handler: () => DeleteBill(item.id)}]" >
          <span>￥{{item.money}}</span>
          <i slot="icon" class="fa" v-bind:class="item.fontStyle" width="24" height="24"></i>
        </mt-cell-swipe>
      </li>
      <li v-if="loading" style="text-align: center">
        <mt-spinner :type="3" color="#26a2ff"></mt-spinner>
      </li>
      <li v-else-if="loadMore" v-on:click="GetListData" style="text-align: center">
        点击更多
      </li>
    </ul>
  </div>

</template>
<script>
  import { Toast } from 'mint-ui';
  // 按需引入echart模板
  let echarts = require('echarts/lib/echarts');
  require('echarts/lib/chart/pie');
  require('echarts/lib/component/tooltip');
  require('echarts/lib/component/title');


  export default{
    data(){
      return{
        listData:[],//列表数据
        chartData:[],// 图表数据
        date:new Date(), // 时间
        loadMore:false,
        loading:false
      }
    },
    methods:{
      DeleteBill(id){
        this.$http.post('/bill/DeleteBill', {
          key: id
        }).then(response => {
          if(response.body.result.result)
          {
            Toast("删除成功");
            this.GetChartData();
            this.GetListData();
          }else
          {
            Toast(response.body.result.data)
          }
        }, response => {
          Toast("服务器连接失败");
        });
      },
      // 获取图表数据
      GetChartData(){
        this.$http.post('/bill/GetCount', {
          Date: this.date,
          Type:1,
          User: '1'
        }).then(response => {
          if(response.body.result.result)
          {
            this.chartData = response.body.result.data;
          }else
          {
            Toast(response.body.result.data)
          }
        }, response => {
          Toast("获取数据出错");
        });
      },
      // 获取列表数据
      GetListData(){
        this.loading=true;
        this.$http.post('/bill/GetBills', {
          Date:this.date,
          SkipCount:this.listData.length,
          Type:1,
          User: '1',
        }).then(response => {
          if(response.body.result.result)
          {
            let newlistdata =[...this.listData,...response.body.result.data.items];
            this.listData = newlistdata;
            this.loadMore = response.body.result.data.totalCount>this.listData.length;
          }else
          {
            Toast(response.body.result.data);
          }
          this.loading=false;
        }, response => {
          this.loading=false;
          Toast("获取数据出错");
        });
      },
      // 绘制图表
      DrawChart(){
        // 基于准备好的dom，初始化echarts实例
        let myChart = echarts.init(document.getElementById('Chart'));
        let data = this.chartData;
        let count =0;   // 从新计算总值
        for (let i of this.chartData) {
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
    },
    // 监测变化
    watch:{
      chartData:function () {
        this.DrawChart(); // 绘制表格

      }
    },
    // 创建后执行
    created(){
      this.GetChartData();
      this.GetListData();
    }
  }
</script>

<style scoped>
  #Chart{
    height: 300px;
    width: 100%;
  }
  ul{
    list-style: none;
    padding-left: 0;
  }
  ul li{
    text-align: left;
    margin-bottom: 5px;
  }
  .bottom{
    position: fixed;
    height: 1px;
    width: 100%;
    bottom: 65px;
  }
</style>
