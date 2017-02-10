<template>
<div>
  <h1>Products</h1>
  <div class="row">
    <div class="col-md-9">
      
      <div class="col-md-3" v-for="product in products"> 
        <product-detail-card :product="product" track-by="id"></product-detail-card>        
      </div>

    </div>
    <div class="col-md-3">
      <shopping-cart></shopping-cart>
    </div>
  </div>
</div>

</template>

<script>
import ProductDetailCard from './ProductDetailCard.vue'
import ShoppingCart from './ShoppingCart.vue'
import { mapActions, mapState } from 'vuex'

export default {
  name: 'product-list',
  components: {
    'ProductDetailCard': ProductDetailCard,
    'ShoppingCart': ShoppingCart
  },
  data () {
    return {

    }
  },
  computed: mapState({
    products: state => state.products.all
  }),
  methods: mapActions([
    'getProducts',
    'getSavedCart'
  ]),
  created () {
    this.getProducts()
    this.getSavedCart()
  }
}
</script>