using System;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json.Serialization;
using SF.WebServer.Api;

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


            var builder = new ContainerBuilder();

            builder.RegisterType<MemCartRepository>().As<ICartRepository>();
            builder.RegisterType<MemProductRepository>().As<IProductRepository>();


            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseWebApi(httpConfig);

            var fileSystem = new PhysicalFileSystem("./app");
            app.UseFileServer(new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                FileSystem = fileSystem
            });
        }
    }


}
