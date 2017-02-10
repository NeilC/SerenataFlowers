using System.Collections.Generic;
using SF.WebServer.Model;

namespace SF.WebServer.Api
{
    public interface ICartRepository
    {
        List<Cart> GetAll();
        Cart GetById(string id);
        Cart Add(Cart cart);
    }
}