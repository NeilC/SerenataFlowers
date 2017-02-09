using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Serilog;
using SF.WebServer.Model;

namespace SF.WebServer.Api
{
    [RoutePrefix("cart")]
    public class CartController : ApiController
    {

        [HttpGet]
        [Route("list")]
        public IHttpActionResult ListContents()
        {
            var items = new List<Product>() {
                new Product() { ID = 1, Name = "Bouquet Roses 1", Description = "bouquet of Roses 1"},
                new Product() { ID = 2, Name = "Bouquet Roses 2", Description = "bouquet of Roses 2"},
                new Product() { ID = 3, Name = "Bouquet Roses 3", Description = "bouquet of Roses 3"},
                new Product() { ID = 4, Name = "Bouquet Roses 4", Description = "bouquet of Roses 4"}
            };


            if (Request.Properties.ContainsKey("cid"))
                Log.Information("Client with {tag} listed content of cart", Request.Properties["cid"]);
            else
                Log.Warning("Client not tagged");

            return Ok(items);
        }



        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddItemToCart(Product product)
        {


            return Ok();
        }

        [HttpDelete]
        [Route("remove")]
        public IHttpActionResult RemoveItemFromCart(int productIdToRemove)
        {

            return Ok();
        }


        [HttpPost]
        [Route("clear")]
        public IHttpActionResult ClearCart()
        {

            return Ok();
        }

    }
}
