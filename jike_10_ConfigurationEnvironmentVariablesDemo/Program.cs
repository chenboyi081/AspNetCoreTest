using Microsoft.Extensions.Configuration;
using System;

namespace jike_10_ConfigurationEnvironmentVariablesDemo
{
    /// <summary>
    /// 环境变量配置应用程序，适用于Docker和K8s，以及一些特殊情况下使用。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            //builder.AddEnvironmentVariables();

            //var configurationRoot = builder.Build();
            //Console.WriteLine($"key1:{configurationRoot["key1"]}");


            //#region 分层键
            //var section = configurationRoot.GetSection("SECTION1");
            //Console.WriteLine($"KEY3:{section["KEY3"]}");

            //var section2 = configurationRoot.GetSection("SECTION1:SECTION2");
            //Console.WriteLine($"KEY4:{section2["KEY4"]}");
            //#endregion

            #region 前缀过滤(下面示例只显示带有前缀的系统变量的值)
            builder.AddEnvironmentVariables("XIAO_");
            var configurationRoot = builder.Build();
            Console.WriteLine($"KEY1:{configurationRoot["KEY1"]}");
            Console.WriteLine($"KEY2:{configurationRoot["KEY2"]}");
            #endregion
        }
    }
}
