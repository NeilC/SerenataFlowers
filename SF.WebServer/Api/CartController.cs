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
                new Product() { ID = 1, Name = "Bouquet Roses 1", Description = "bouquet of Roses 1", Price = 12.01M, Stock = 10},
                new Product() { ID = 2, Name = "Bouquet Roses 2", Description = "bouquet of Roses 2", Price = 12.01M, Stock = 10},
                new Product() { ID = 3, Name = "Bouquet Roses 3", Description = "bouquet of Roses 3", Price = 12.01M, Stock = 10},
                new Product() { ID = 4, Name = "Bouquet Roses 4", Description = "bouquet of Roses 4", Price = 12.01M, Stock = 10}
            };

        IProductRepository ProductRepository { get; set; }
        ICartRepository CartRepository { get; set; }


        public CartController(IProductRepository productRepository, ICartRepository cartRepository)
        {
            ProductRepository = productRepository;
            CartRepository = cartRepository;
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult ListContents()
        {

            if (Request.Properties.ContainsKey("cid"))
                Log.Information("Client with {tag} listed content of cart", Request.Properties["cid"]);
            else
                Log.Warning("Client not tagged");


            var cartId = Request.Properties["cid"] as string;
            var cart = CartRepository.GetById(cartId);

            if (cart == null)
            {
                cart = new Cart(Guid.Parse(cartId), ProductRepository);
                CartRepository.Add(cart);
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

            var cart = CartRepository.GetById(cartId);


            if (cart == null)
            {
                cart = new Cart(Guid.Parse(cartId), ProductRepository);
                CartRepository.Add(cart);
            }

            var product = ProductRepository.GetById(productId);

            if (product == null || product.Stock < 1) return NotFound();

            cart.AddToCart(product);
            Log.Information("Client {tag} added {@product} to thier cart", cartId, product);
            return Ok();
        }

        [HttpDelete]
        [Route("remove/{productId}")]
        public IHttpActionResult RemoveItemFromCart(int productId)
        {

            var cartId = Request.Properties["cid"] as string;
            if (cartId == null)
                return BadRequest();

            var cart = CartRepository.GetById(cartId);

            if (cart == null)
            {
                cart = new Cart(Guid.Parse(cartId), ProductRepository);
                CartRepository.Add(cart);
            }

            cart.RemoveFromCart(productId);
            Log.Information("Client {tag} removed product with id {productId} from thier cart", cartId, productId);

            return Ok();
        }


        [HttpPost]
        [Route("clear")]
        public IHttpActionResult ClearCart()
        {
            var cartId = Request.Properties["cid"] as string;
            if (cartId == null)
                return BadRequest();

            var cart = CartRepository.GetById(cartId);
            cart?.ClearCart();

            Log.Information("Client {tag} cleared thier cart", cartId);

            return Ok();
        }

    }
}
