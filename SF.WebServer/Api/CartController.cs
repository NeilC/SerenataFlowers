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
        List<Product> items = new List<Product>() {
                new Product() { ID = 1, Name = "Bouquet Roses 1", Description = "bouquet of Roses 1", Price = 12.00M, Stock = 10},
                new Product() { ID = 2, Name = "Bouquet Roses 2", Description = "bouquet of Roses 2", Price = 12.00M, Stock = 10},
                new Product() { ID = 3, Name = "Bouquet Roses 3", Description = "bouquet of Roses 3", Price = 12.00M, Stock = 10},
                new Product() { ID = 4, Name = "Bouquet Roses 4", Description = "bouquet of Roses 4", Price = 12.00M, Stock = 10}
            };


        [HttpGet]
        [Route("list")]
        public IHttpActionResult ListContents()
        {

            if (Request.Properties.ContainsKey("cid"))
                Log.Information("Client with {tag} listed content of cart", Request.Properties["cid"]);
            else
                Log.Warning("Client not tagged");


            var cartId = Request.Properties["cid"] as string;
            var cart = Program.CartRepository.FirstOrDefault(c => c.ID.ToString() == cartId.ToString());

            if (cart == null)
            {
                cart = new Cart(Guid.Parse(cartId));
                Program.CartRepository.Add(cart);
            }

            return Ok(cart);
        }



        [HttpPost]
        [Route("add/{productId}")]
        public IHttpActionResult AddItemToCart(int productId)
        {
            var cartId = Request.Properties["cid"] as string;

            if (cartId == null)
                return BadRequest();

            var cart = Program.CartRepository.FirstOrDefault(c => c.ID.ToString() == cartId.ToString());

            if (cart == null)
            {
                cart = new Cart(Guid.Parse(cartId));
                Program.CartRepository.Add(cart);
            }

            var product = items.FirstOrDefault(p => p.ID == productId);

            if (product == null || product.Stock < 1) return NotFound();

            cart.AddToCart(product);
            return Ok();
        }

        [HttpDelete]
        [Route("remove/{productId}")]
        public IHttpActionResult RemoveItemFromCart(int productId)
        {

            var cartId = Request.Properties["cid"] as string;
            if (cartId == null)
                return BadRequest();

            var cart = Program.CartRepository.FirstOrDefault(c => c.ID.ToString() == cartId.ToString());
            if (cart == null)
            {
                cart = new Cart(Guid.Parse(cartId));
                Program.CartRepository.Add(cart);
            }

            cart.RemoveFromCart(productId);
            return Ok();
        }


        [HttpPost]
        [Route("clear")]
        public IHttpActionResult ClearCart()
        {
            var cartId = Request.Properties["cid"] as string;
            if (cartId == null)
                return BadRequest();

            var cart = Program.CartRepository.FirstOrDefault(c => c.ID.ToString() == cartId.ToString());
            cart?.ClearCart();


            return Ok();
        }

    }
}
