const state = {
  contents: []
}

const mutations = {
  RETRIEVE_CART (state) {

  },

  ADD_TO_CART (state, productId) {
    const record = state.contents.find(product => product.id === productId)

    if (!record) {
      state.added.push({
        id: productId,
        quantity: 1
      })
    } else {
      record.quantity++
    }
  },

  REMOVE_FROM_CART (state, item) {
    const index = state.contents.findIndex(contents => contents.id === item.id)
    state.contents.splice(index, 1)
  }
}

export default {
  state,
  mutations
}
