using System.Collections.Generic;
using SF.WebServer.Model;

namespace SF.WebServer.Api
{
    public interface IProductRepository
    {

        List<Product> GetAll();
        Product GetById(int id);

    }
}