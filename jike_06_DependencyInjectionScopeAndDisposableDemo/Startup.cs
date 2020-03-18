using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace jike_06_DependencyInjectionScopeAndDisposableDemo
{
    using jike_06_DependencyInjectionScopeAndDisposableDemo.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IOrderService, DisposableOrderService>();
            //services.AddSingleton<IOrderService>(new DisposableOrderService());
            services.AddScoped<IOrderService>(p => new DisposableOrderService());       //如果改成单例模式，不会被释放。如果改成瞬时，会释放

            //var service = new DisposableOrderService();
            //services.AddSingleton<IOrderService>(service);     //自己创建对象，不会释放，在controller中使用IHostApplicationLifetime
            
            services.AddSingleton<IOrderService,DisposableOrderService>();     //在容器中使用，就会释放
            
            //services.AddTransient<IOrderService, DisposableOrderService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //从根容器获取服务


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
