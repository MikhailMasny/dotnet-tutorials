using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Masny.DataTransfer.UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("https://*:54576");
                    webBuilder.UseStartup<Startup>();
                });
    }
}