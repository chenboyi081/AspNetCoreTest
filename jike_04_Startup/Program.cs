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
                     Console.WriteLine("ִ�з�����ConfigureAppConfiguration");
                 })
                .ConfigureServices(services => {
                    Console.WriteLine("ִ�з�����ConfigureServices");
                })
                .ConfigureHostConfiguration(builder => {
                    Console.WriteLine("ִ�з�����ConfigureHostConfiguration");
                })
                .ConfigureLogging(builder => {
                    Console.WriteLine("ִ�з�����ConfigureLogging");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    Console.WriteLine("ִ�з�����ConfigureWebHostDefaults");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
