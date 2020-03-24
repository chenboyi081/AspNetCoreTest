using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jike_07_DependencyInjectionAutofacDemo.Services
{
    using Castle.DynamicProxy;
    public class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Intercept before,Method:{invocation.Method.Name}");
            invocation.Proceed();     //当前方法的调用
            Console.WriteLine($"Intercept after,Method:{invocation.Method.Name}");
        }
    }
}
