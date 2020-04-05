using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
namespace jike_11_Configuration_FileDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            var configurationRoot = builder.Build();

            Console.WriteLine($"Key1:{configurationRoot["Key1"]}");
            Console.WriteLine($"Key5:{configurationRoot["Key5"]}");
            Console.WriteLine($"Key6:{configurationRoot["Key6"]}");
        }
    }
}
