import Vue from 'vue'
import VueRouter from 'vue-router'
import VueResource from 'vue-resource'

import store from './store'

import ProductList from './components/productlist'
import Cart from './components/ShoppingCart'

Vue.use(VueRouter)
Vue.use(VueResource)

const routes = [
  { path: '/products', component: ProductList },
  { path: '/cart', component: Cart }
]

/* eslint-disable no-new */
/* eslint-disable no-unused-vars */
const router = new VueRouter({
  routes: routes
})

const app = new Vue({
  router,
  store
}).$mount('#app')
