using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace jike_14_Configuration_Custom
{
    //14.自定义配置数据源：低成本实现定制化配置方案
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddMyConfiguration();
            var configRoot = builder.Build();
            ChangeToken.OnChange(() => configRoot.GetReloadToken(), () =>
            {
                Console.WriteLine($"lastTime:{configRoot["lastTime"]}");
            });

            Console.WriteLine("开始了");
            Console.ReadKey();
        }
    }
}
