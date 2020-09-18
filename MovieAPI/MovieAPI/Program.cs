using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MovieAPI
{
    public class Program
    {

        // TODO: add kestrel configuration
        // TODO: build IConfiguration here

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()           
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("EpkaEnv")}.json",false, true)
            .AddEnvironmentVariables()
            .Build();
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseConfiguration(Configuration);
                });
    }
}
