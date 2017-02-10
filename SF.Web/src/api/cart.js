import Vue from 'vue'
import VueResource from 'vue-resource'

Vue.use(VueResource)

const rootUrl = 'http://localhost:9092/'

export default {
  list (cb) {
    Vue.http.get(rootUrl + 'cart/list').then(cb)
  },
  addToCart (productId, cb) {
    Vue.http.post(rootUrl + 'cart/add/' + productId, {}).then(cb)
  },
  removeFromCart (productId, cb) {
    Vue.http.delete(rootUrl + 'cart/remove/' + productId, productId).then(cb)
  },
  clearCart (cb) {
    Vue.http.post(rootUrl + 'cart/clear', {}).then(cb)
  }

}
