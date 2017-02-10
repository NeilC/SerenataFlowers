<template>
  <div>
    <h3>Cart</h3>
    <div class="media" v-for="product in cartProducts">
      <div class="media-left">
        <a href="#"><img alt="64x64" class="media-object" src="http://placehold.it/64x64"></a>
      </div>
      <div class="media-body">
        <span>
          <h4 class="media-heading"> {{product.name}} 
          <button class="btn btn-xs btn-warning" @click="removeFromCart(product)"> <i class="fa fa-close"></i> </button>
          
          </h4>          
        </span>

         <p>{{product.price}} - quantity: {{product.quantity}}</p>
         <p>Description</p>
      </div>
    </div>

    <hr>

    <ul class="list-group">
      <li class="list-group-item">Total: {{total}}</li>
    </ul>
  </div>
</template>


<script>
import { mapState, mapGetters, mapActions } from 'vuex'
export default {
  name: 'shoppingcart',
  data () {
    return {
    }
  },
  computed: {
    ...mapGetters([
      'cartProducts',
      'total'
    ]),
    ...mapState({
      products: state => state.products.all
    })
  },
  methods: mapActions([
    'removeFromCart'
  ])
}
</script>


<style>
.quantity {
  width: 45px;
}
</style>