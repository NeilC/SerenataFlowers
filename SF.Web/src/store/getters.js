export const cartProducts = state => {
  return state.cart.contents.map(({ id, quantity }) => {
    const product =
      state
        .products.all
        .find(product => product.id === id)

    return {
      ...product,
      quantity
    }
  })
}

export const itemsQuantity = state => {
  return cartProducts(state).reduce((quantity, item) => {
    return quantity + item.quantity
  }, 0)
}

export const total = state => {
  return cartProducts(state).reduce((total, item) => {
    return (total + (item.price * item.quantity))
  }, 0)
}
