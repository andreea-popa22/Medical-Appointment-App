using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddDbContext<popaadbEntities>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("popaadbEntities")));

            //var host = new WebHostBuilder()
            //            .UseKestrel()
            //            .UseContentRoot(System.IO.Directory.GetCurrentDirectory())
            //            .UseIISIntegration()
            //            .UseStartup<Startup>()
            //            .Build();

            //host.Run();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
