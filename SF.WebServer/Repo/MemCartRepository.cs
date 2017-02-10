using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.WebServer.Model;

namespace SF.WebServer.Api
{
    public class MemCartRepository : ICartRepository
    {

        public static List<Cart> CartRepository = new List<Cart>();

        public List<Cart> GetAll()
        {
            return CartRepository;
        }

        public Cart GetById(string id)
        {
            return CartRepository.FirstOrDefault(c => c.ID.ToString() == id);
        }

        public Cart Add(Cart cart)
        {
            CartRepository.Add(cart);
            return CartRepository.FirstOrDefault(c => c.ID == cart.ID);

        }
    }
}
