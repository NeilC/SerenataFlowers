using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Serilog;
using SF.WebServer.Api;
using SF.WebServer.Model;

namespace SF.WebServer
{
    class Program
    {

        public static List<Cart> CartRepository = new List<Cart>();

        public static List<Product> ProductsRepository = new List<Product>() {
                new Product() { ID = 1, Name = "Bouquet Roses 1", Description = "bouquet of Roses 1", Price = 12.00M, Stock = 10},
                new Product() { ID = 2, Name = "Bouquet Roses 2", Description = "bouquet of Roses 2", Price = 12.00M, Stock = 10},
                new Product() { ID = 3, Name = "Bouquet Roses 3", Description = "bouquet of Roses 3", Price = 12.00M, Stock = 10},
                new Product() { ID = 4, Name = "Bouquet Roses 4", Description = "bouquet of Roses 4", Price = 12.00M, Stock = 10}
            };


        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();




            using (WebApp.Start<Startup>("http://serenataflowers.com:9092/"))
            {
                Log.Information("Server Started at http://localhost:9092");
                Log.Information("Press any key to shutdown server");

                Console.ReadKey();
            }

        }
    }
}
