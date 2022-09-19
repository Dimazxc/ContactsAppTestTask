import Vue from 'vue'
import App from './App.vue'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import moment from "moment";
import axios from "axios";
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.config.productionTip = false

const api = axios.create({
  baseURL: "http://localhost:5000"
})

const axiosPlugin = {
  install(Vue) {
    Vue.prototype.$api = api;
  }
}

Vue.filter('dateFormat', function(value) {
  if (value) {
    return moment(String(value)).format('YYYY.MM.DD')
  }
});

Vue.use(axiosPlugin);
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)

new Vue({
  render: h => h(App),
}).$mount('#app')
