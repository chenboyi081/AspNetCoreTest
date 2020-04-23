using System;
using System.Collections.Generic;
using System.Text;
using jike_14_Configuration_Custom;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// ConfigurationBuilderd的扩展方法：（供外部使用）
    /// </summary>
    public static class MyConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddMyConfiguration(this IConfigurationBuilder builder)
        {
            builder.Add(new MyConfigurationSource());
            return builder;
        }
    }
}
