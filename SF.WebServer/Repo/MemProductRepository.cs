using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.WebServer.Model;

namespace SF.WebServer.Api
{
    public class MemProductRepository : IProductRepository
    {

        public static List<Product> ProductCollection = new List<Product>() {
                new Product() { ID = 1, Name = "Bouquet Roses 1", Description = "bouquet of Roses 1", Price = 12.01M, Stock = 10},
                new Product() { ID = 2, Name = "Bouquet Roses 2", Description = "bouquet of Roses 2", Price = 12.01M, Stock = 10},
                new Product() { ID = 3, Name = "Bouquet Roses 3", Description = "bouquet of Roses 3", Price = 12.01M, Stock = 10},
                new Product() { ID = 4, Name = "Bouquet Roses 4", Description = "bouquet of Roses 4", Price = 12.01M, Stock = 10}
            };
        public List<Product> GetAll()
        {
            return ProductCollection;
        }

        public Product GetById(int id)
        {
            return ProductCollection.FirstOrDefault(p => p.ID == id);
        }
    }
}
