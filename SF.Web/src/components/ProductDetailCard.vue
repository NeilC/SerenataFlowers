<template>
<div class="item active">
  <div class="row">
    <div class="col-sm-12">
      <div class="col-item">
        <div class="photo">
          <img src="http://placehold.it/350x260" class="img-responsive" alt="a" />
        </div>
        <div class="info">
          <div class="row">
            <div class="price col-md-12">
              <h5>
                {{product.name}}</h5>
              <h5 class="price-text-color">
                {{product.price}}</h5>
            </div>

          </div>
          <div class="separator clear-left">

            <p class="btn-add">
              
              <button class="btn btn-success btn-sm" @click="addToCart(product)">
              <i class="fa fa-shopping-cart"></i>
              Add to Cart</button> 
              
            </p>
          </div>
          <div class="clearfix">
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  props: {
    product: Object
  },
  name: 'product-detail-card',
  methods: mapActions([
    'addToCart'
  ])
}
</script>


<style scoped>
.col-item {
  border: 1px solid #E1E1E1;
  border-radius: 5px;
  background: #FFF;
}

.col-item .photo img {
  margin: 0 auto;
  width: 100%;
}

.col-item .info {
  padding: 10px;
  border-radius: 0 0 5px 5px;
  margin-top: 1px;
}

.col-item:hover .info {
  background-color: #d9f0f9;
}

.col-item .price {
  /*width: 50%;*/
  float: left;
  margin-top: 5px;
}

.col-item .price h5 {
  line-height: 20px;
  margin: 0;
}

.price-text-color {
  color: #219FD1;
}

.col-item .info .rating {
  color: #777;
}

.col-item .rating {
  /*width: 50%;*/
  float: left;
  font-size: 17px;
  text-align: right;
  line-height: 52px;
  margin-bottom: 10px;
  height: 52px;
}

.col-item .separator {
  border-top: 1px solid #E1E1E1;
}

.clear-left {
  clear: left;
}

.col-item .separator p {
  line-height: 20px;
  margin-bottom: 0;
  margin-top: 10px;
  text-align: center;
}

.col-item .separator p i {
  margin-right: 5px;
}

.col-item .btn-add {
  width: 50%;
  float: left;
}

.col-item .btn-add {
  border-right: 1px solid #E1E1E1;
}

.col-item .btn-details {
  width: 50%;
  float: left;
  padding-left: 10px;
}

.controls {
  margin-top: 20px;
}

[data-slide="prev"] {
  margin-right: 10px;
}
</style>