<template>
  <div>
    <h3>Cart</h3>
    <div class="media">
      <div class="media-left">
        <a href="#"> <img alt="64x64" class="media-object" src="http://placehold.it/64x64"> </a>
      </div>
      <div class="media-body">
        <h4 class="media-heading"> Flowers </h4>
         
          <span>Quanity:  <input class="input quantity" type="text"></span>
      
      </div>
    </div>

    <hr>

    <ul class="list-group">
      <li class="list-group-item">Total: {{total}}</li>
    </ul>
  </div>
</template>


<script>
export default {
  name: 'shoppingcart',
  data () {
    return {
      total: 10,
      items: []
    }
  }
}
</script>


<style>
.quantity {
  width: 45px;
}
</style>