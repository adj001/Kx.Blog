using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace kx.Blog.HttpApi.Hosting
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                      .ConfigureWebHostDefaults(builder =>
                      {
                          builder
                                  .UseStartup<Startup>();
                      }).UseAutofac().Build().RunAsync();
        }

    }
}

//        public static int Main(string[] args)
//        {
//            Log.Logger = new LoggerConfiguration()
//#if DEBUG
//                .MinimumLevel.Debug()
//#else
//                .MinimumLevel.Information()
//#endif
//                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
//                .Enrich.FromLogContext()
//                .WriteTo.Async(c => c.File("Logs/logs.txt"))
//                .CreateLogger();

//            try
//            {
//                Log.Information("Starting web host.");
//                CreateHostBuilder(args).Build().Run();
//                return 0;
//            }
//            catch (Exception ex)
//            {
//                Log.Fatal(ex, "Host terminated unexpectedly!");
//                return 1;
//            }
//            finally
//            {
//                Log.CloseAndFlush();
//            }
//        }

//        internal static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseIISIntegration()
//                    .UseStartup<Startup>();
//                })
//                .UseAutofac().Build()
//                .UseSerilog();
//    }
//}
