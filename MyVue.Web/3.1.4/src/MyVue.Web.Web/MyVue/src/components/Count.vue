<template>
  <div id="Count">
    <div class="Count_Top">
      <label >当前历史记账金额（元）</label><br>
      <label class="Money">{{TotallCount}}</label>
    </div>
    <div>
      <mt-navbar v-model="selected">
        <router-link to="/Count" v-bind:class="ClassMenuMonth" v-on:click.native="select(0)" >当月 </router-link>
        <router-link to="/Count/year"  v-bind:class="ClassMenuyear" v-on:click.native="select(1)"> 当年 </router-link>
      </mt-navbar>
      <router-view ></router-view>
    </div>
  </div>
</template>

<script>
  import { Toast } from 'mint-ui';
  export default {
    methods: {
      select(m){
        this.selected = m;
      },
      GetTotallCount(){
        this.$http.post('/bill/GetTotallCount', {
          User: '1'
        }).then(response => {
          if(response.body.result.result)
          {
            this.TotallCount=response.body.result.data;
          }else
          {
            Toast(response.body.result.data)
          }
        }, response => {
          Toast("获取数据出错")
        });
      },
    },
    created(){
      this.GetTotallCount();
    },
    data() {
      return {
        TotallCount: 0,
        selected:-1,
      }
    },
    computed:{ // 使用计算属性给菜单动态添加样式
      ClassMenuMonth(){
        return{
          'mint-tab-item':true,
          'is-selected':this.selected==0,
        }
      },
      ClassMenuyear(){
        return{
          'mint-tab-item':true,
          'is-selected':this.selected==1,
        }
      }
    },
  };
</script>
<style scoped>
  #Count .Count_Top{
    padding: 16px;
    color: #26a2ff;
  }
  #Count .Count_Top label{
    font-size: 12px;
  }
  #Count .Count_Top .Money{
    font-size: 30px;
  }
  #Count{
    margin-top: 0;
    position: relative;
    height: auto;
    background-color: #eee;}
  .mint-tab-item{
    padding: 12px;
  }
</style>
