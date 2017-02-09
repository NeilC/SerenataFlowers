<template>
<div>
  <h1>Products</h1>
  <div class="row">
    <div class="col-md-9">
      <product-detail-card></product-detail-card>
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
import { mapActions } from 'vuex'

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
  methods: mapActions([
    'getProducts'
  ]),
  created () {
    this.getProducts()
  }
}
</script>