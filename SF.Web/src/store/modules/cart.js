import cartApi from '../../api/cart.js'

const state = {
  contents: []
}

const mutations = {
  RETRIEVE_CART (state) {

  },

  ADD_TO_CART (state, productIdToAdd) {
    const product = state.contents.find(product => product.id === productIdToAdd)

    if (!product) {
      state.contents.push({
        id: productIdToAdd,
        quantity: 1
      })
    } else {
      product.quantity++
    }

    cartApi.addToCart(productIdToAdd)
  },

  REMOVE_FROM_CART (state, productToRemove) {
    const index = state.contents.findIndex(contents => contents.id === productToRemove.id)
    state.contents.splice(index, 1)

    cartApi.removeFromCart(productToRemove.id)
  }
}

export default {
  state,
  mutations
}
