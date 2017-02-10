using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.WebServer.Model
{
    public class Cart
    {

        public Guid ID { get; set; }
        public List<CartProduct> Contents { get; private set; }
        public decimal SubTotal { get; private set; }



        public Cart(Guid CartId)
        {
            if (CartId == null)
                throw new ArgumentException("Cart needs an ID");

            ID = CartId;
            Contents = new List<CartProduct>();
        }


        public void AddToCart(Product product)
        {
            var item = Contents.FirstOrDefault(p => p.ID == product.ID);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                Contents.Add(new CartProduct()
                {
                    ID = product.ID,
                    Quantity = 1,
                    Price = product.Price
                });
            }

            UpdateSubtotal();

        }



        public void RemoveFromCart(int productId)
        {
            var product = Contents.FirstOrDefault(p => p.ID == productId);
            Contents.Remove(product);
            UpdateSubtotal();

        }

        private void UpdateSubtotal()
        {
            SubTotal = 0M;
            foreach (var cartProduct in Contents)
            {
                var product = Program.ProductsRepository.FirstOrDefault(p => p.ID == cartProduct.ID);

                if (product != null)
                    SubTotal += product.Price * cartProduct.Quantity;

            }
        }

        public void ClearCart()
        {
            Contents.Clear();
            SubTotal = 0M;
        }



    }

    public class CartProduct
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }


    }

}
