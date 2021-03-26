using Masny.DotNet.DataTransfer.ClientService.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.DotNet.DataTransfer.ClientService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApplicationConfig.GenerateDate = Convert.ToBoolean(args[1]);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls($"https://*:{args[0]}");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
