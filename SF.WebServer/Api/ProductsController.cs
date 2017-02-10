using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using SF.WebServer.Model;

namespace SF.WebServer.Api
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        public IProductRepository ProductRepository { get; set; }

        public ProductsController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult All()
        {

            return Ok(ProductRepository.GetAll());
        }

    }
}
