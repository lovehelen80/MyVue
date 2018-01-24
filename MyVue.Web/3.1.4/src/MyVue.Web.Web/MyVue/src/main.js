// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import VueResource from 'vue-resource' //引入vue-resource
import MintUi from 'mint-ui'    // 引入mint-ui
import 'mint-ui/lib/style.css'  // 引入mint-ui的样式
Vue.use(MintUi);
Vue.use(VueResource);
Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})
