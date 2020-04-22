using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
namespace jike_11_Configuration_FileDemo
{
    class Program
    {
        //另可参考：【ASP.NET Core快速入门】（六）配置的热更新、配置的框架设计：https://www.cnblogs.com/wyt007/p/8053968.html
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);    
            //builder.AddIniFile("appsettings.ini");  //后添加的文件优先级更高
            var configurationRoot = builder.Build();

            //IChangeToken仅在文件发生变更时触发
            IChangeToken token = configurationRoot.GetReloadToken();
            //IChangeToken只能使用一次,所以  使用Onchange方法绑定configurationRoot.GetReloadToken()，每次获取新的token
            ChangeToken.OnChange(() => configurationRoot.GetReloadToken(), () =>
            {
                Console.WriteLine($"Key1:{configurationRoot["Key1"]}");
                Console.WriteLine($"Key2:{configurationRoot["Key2"]}");
                Console.WriteLine($"Key3:{configurationRoot["Key3"]}");
            });

            //Console.WriteLine($"Key1:{configurationRoot["Key1"]}");
            //Console.WriteLine($"Key2:{configurationRoot["Key2"]}");
            //Console.WriteLine($"Key3:{configurationRoot["Key3"]}");
            Console.ReadKey();
        }
    }
}
