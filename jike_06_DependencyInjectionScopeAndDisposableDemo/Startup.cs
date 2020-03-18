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
            services.AddScoped<IOrderService>(p => new DisposableOrderService());       //����ĳɵ���ģʽ�����ᱻ�ͷš�����ĳ�˲ʱ�����ͷ�

            //var service = new DisposableOrderService();
            //services.AddSingleton<IOrderService>(service);     //�Լ��������󣬲����ͷţ���controller��ʹ��IHostApplicationLifetime
            
            services.AddSingleton<IOrderService,DisposableOrderService>();     //��������ʹ�ã��ͻ��ͷ�
            
            //services.AddTransient<IOrderService, DisposableOrderService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //�Ӹ�������ȡ����


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
