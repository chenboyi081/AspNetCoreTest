using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace jike_04_Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration(builder => {
                     Console.WriteLine("执行方法：ConfigureAppConfiguration");
                 })
                .ConfigureServices(services => {
                    Console.WriteLine("执行方法：ConfigureServices");
                })
                .ConfigureHostConfiguration(builder => {
                    Console.WriteLine("执行方法：ConfigureHostConfiguration");
                })
                .ConfigureLogging(builder => {
                    Console.WriteLine("执行方法：ConfigureLogging");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    Console.WriteLine("执行方法：ConfigureWebHostDefaults");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
