import Vue from 'vue'
import App from './App.vue'
import ElementUI from 'element-ui'
import router from './router.js'

Vue.use(ElementUI)

import 'element-ui/lib/theme-chalk/index.css'

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
