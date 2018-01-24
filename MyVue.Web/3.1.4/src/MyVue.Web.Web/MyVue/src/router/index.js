import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello' // 记账页面
import Count from "@/components/Count" // 统计页面
import MonthCount from "@/components/MonthCount"
import YearCount from "@/components/YearCount"
Vue.use(Router)

export default new Router({
  routes: [
    {path: '/',component: Hello},
    {path: '/Count', component: Count,children:[
      {path: '', component: MonthCount},
      {path: 'year', component: YearCount}
    ]}
  ]
})
