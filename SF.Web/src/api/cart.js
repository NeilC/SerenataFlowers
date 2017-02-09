import Vue from 'vue'
import VueResource from 'vue-resource'

Vue.use(VueResource)

const rootUrl = 'http://localhost:9092/'

export default {
  list (cb) {
    Vue.http.get(rootUrl + 'cart/list').then(cb)
  }
}
