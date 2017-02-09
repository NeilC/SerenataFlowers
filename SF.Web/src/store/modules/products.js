const state = {
  all: []
}

const mutations = {
  RECEIVE_PRODUCTS (state, products) {
    state.all = products
  },

  ADD_TO_CART (state, productId) {
    var product = state.all
      .find(product => product.id === productId)

    product.stock--
  },

  REMOVE_FROM_CART (state, removedProduct) {
    var product = state.all
      .find(product => product.id === removedProduct.id)

    product.stock += removedProduct.quantity
  }
}

export default {
  state,
  mutations
}
