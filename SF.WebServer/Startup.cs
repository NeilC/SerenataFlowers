using System;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;

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
            httpConfig.MessageHandlers.Add(new ClientTagger());

            httpConfig.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            httpConfig.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            httpConfig.Formatters
                .JsonFormatter
                .MediaTypeMappings
                .Add(new RequestHeaderMapping("Accept", "text/html", StringComparison.InvariantCultureIgnoreCase, isValueSubstring: true, mediaType: "application/json"));

            app.UseWebApi(httpConfig);
        }
    }


}
