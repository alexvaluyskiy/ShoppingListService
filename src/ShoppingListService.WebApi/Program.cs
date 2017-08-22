using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Json;

namespace ShoppingListService.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureLogging(builder =>
                {
                    Log.Logger = new LoggerConfiguration()
                        .WriteTo.RollingFile(new JsonFormatter(), "log-{Date}.json")
                        .CreateLogger();

                    builder.AddSerilog(Log.Logger);
                    builder.AddDebug();
                })
                .UseStartup<Startup>()
                .Build();
        }
    }
}
