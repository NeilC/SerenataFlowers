using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace SF.WebServer.Api
{
    [RoutePrefix("cart")]
    public class CartController : ApiController
    {

        [HttpGet]
        [Route("list")]
        public Task<OkResult> ListContents()
        {


            return Task.FromResult(Ok());
        }

    }
}
