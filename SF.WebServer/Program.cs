using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            using (WebApp.Start<Startup>("http://localhost:9092/"))
            {
                Log.Information("Server Started at http://localhost:9092");
                Log.Information("Press any key to shutdown server");

                Console.ReadKey();
            }

        }
    }
}
