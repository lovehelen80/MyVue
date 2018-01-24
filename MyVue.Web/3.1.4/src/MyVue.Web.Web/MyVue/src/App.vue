<template>
  <div id="app">
    <router-view class="Content"></router-view>
    <mt-tabbar :fixed="true">
      <router-link to="/" v-bind:class="ClassMenuHello" v-on:click.native="select(0)" > <i class="fa fa-edit"></i> 记账 </router-link>
      <router-link to="/Count"  v-bind:class="ClassMenuCount" v-on:click.native="select(1)"> <i class="fa fa-bar-chart"></i> 统计 </router-link>
    </mt-tabbar>
  </div>
</template>

<script>
  export default {
    name: 'app',
    data(){
      return{
        selected:-1,
      }
    },
    computed:{ // 使用计算属性给菜单动态添加样式
      ClassMenuHello(){
        return{
          'mint-tab-item':true,
          'is-selected':this.selected==0,
        }
      },
      ClassMenuCount(){
        return{
          'mint-tab-item':true,
          'is-selected':this.selected==1,
        }
      }
    },
    methods:{
      select(m){ // 给组件绑定事件时需要使用.native 例如绑定点击事件使用 v-on:click.native="f"
        this.selected=m;
      },
    }
  }
</script>

<style scoped>
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }
  #app .mint-tab-item{
    font-size: 20px;
    padding: 15px;
  }
  #app .Content{
    padding-bottom: 56px;
  }
</style>
