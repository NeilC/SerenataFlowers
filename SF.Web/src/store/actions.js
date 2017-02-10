import productsApi from 'src/api/products'
import cartApi from 'src/api/cart'

export const getProducts = ({ commit }) => {
  productsApi.getProducts(products => {
    commit('RECEIVE_PRODUCTS', products.body)
  })
}

export const getSavedCart = ({ commit }) => {
  cartApi.list(response => {
    commit('RETRIEVE_CART', response.body.contents)
  })
}

export const clearCart = ({ commit }) => {
  cartApi.clearCart()
  commit('CLEAR_CART')
}

export const addToCart = ({ commit }, product) => {
  cartApi.addToCart(product.id)

  if (product.stock > 0) {
    commit('ADD_TO_CART', product.id)
  }
}

export const removeFromCart = ({ commit }, product) => {
  commit('REMOVE_FROM_CART', product)
}

