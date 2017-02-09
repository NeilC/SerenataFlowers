using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(SF.WebServer.Startup))]

namespace SF.WebServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            HttpConfiguration httpConfig = new HttpConfiguration();
            httpConfig.MapHttpAttributeRoutes();

            app.UseWebApi(httpConfig);
        }
    }


}
