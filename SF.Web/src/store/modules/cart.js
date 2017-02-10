import cartApi from '../../api/cart.js'

const state = {
  contents: [],
  total: 0
}

const mutations = {
  CLEAR_CART (state) {
    state.contents = []
  },

  RETRIEVE_CART (state, products) {
    state.contents = products
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
