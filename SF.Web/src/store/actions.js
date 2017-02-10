import productsApi from 'src/api/products'

export const getProducts = ({ commit }) => {
  productsApi.getProducts(products => {
    commit('RECEIVE_PRODUCTS', products.body)
  })
}

export const addToCart = ({ commit }, product) => {
  if (product.stock > 0) {
    commit('ADD_TO_CART', product.id)
  }
}

export const removeFromCart = ({ commit }, product) => {
  commit('REMOVE_FROM_CART', product)
}

