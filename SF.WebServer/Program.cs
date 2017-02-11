using System;
using Microsoft.Owin.Hosting;
using Serilog;

namespace SF.WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .CreateLogger();


            var serverUrl = "http://localhost:9092/";

            using (WebApp.Start<Startup>(serverUrl))
            {
                Log.Information("Server Started at {url}", serverUrl);
                Log.Information("You may navigate to this url to open up the cart");

                Log.Information("Press any key to shutdown server");

                Console.ReadKey();
            }

        }
    }
}
