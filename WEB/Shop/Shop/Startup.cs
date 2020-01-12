    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.ApplicationCore.Interfaces;
using Shop.Infrastructure.Interfaces;
using Shop.Infrastructure.Services;
using Shop.Web.Data;

namespace Shop
{
    public class Startup
    {
     
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped(typeof(IAsyncRepository<>), typeof(GenericEfRepository<>));
            //services.AddScoped<ICatalogViewModelService, CachedCatalogViewModelService>();
            //services.AddScoped<IBasketService, BasketService>();
            //services.AddScoped<IBasketViewModelService, BasketViewModelService>();
            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<CatalogViewModelService>();
            //services.AddScoped<ICatalogItemViewModelService, CatalogItemViewModelService>();
            //services.Configure<CatalogSettings>(Configuration);
            //services.AddSingleton<IUriComposer>(new UriComposer(Configuration.Get<CatalogSettings>()));
            //services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            //services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
            services.AddTransient<IEmailSender, EmailSenderService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller:slugify=Home}/{action:slugify=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
