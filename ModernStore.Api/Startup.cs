using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ModernStore.Domain.Commads.Handlers;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services;
using ModernStore.Infra.Context;
using ModernStore.Infra.Repositories;
using ModernStore.Infra.Sevices;
using ModernStore.Infra.Transactions;

namespace ModernStore.Api
{
    public class Startup
    {
       public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();

            services.AddScoped<ModernStoreDataContext, ModernStoreDataContext>();
            services.AddTransient<IUow, Uow>();
            services.AddTransient<IProtuctRepository, ProdutRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<CustomerCommadHandler, CustomerCommadHandler>();
            services.AddTransient<OrderCommadHandler, OrderCommadHandler>();


            services.AddTransient<IEmailService, EmailService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseCors(x =>
                {
                    x.AllowAnyHeader();
                    x.AllowAnyMethod();
                    x.AllowAnyOrigin();
                });
                app.UseMvc();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
