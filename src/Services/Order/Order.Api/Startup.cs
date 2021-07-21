using EventBus.Messages.Common;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Order.Api.Consumers;
using Order.Application;
using Order.Infrastructure;

namespace Order.Api
{
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
            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);

            //Automapper
            services.AddAutoMapper(typeof(Startup));

            //Mass Transit Rabbit-MQ Configuration
            services.AddMassTransit(c =>
            {
                c.AddConsumer<BasketCheckoutConsumer>();

                c.UsingRabbitMq((context, config) =>
                {
                    config.Host(Configuration["EventBusSettings:HostAddress"]);

                    config.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, cfg =>
                    {
                        cfg.ConfigureConsumer<BasketCheckoutConsumer>(context);
                    });
                });
            });
            services.AddMassTransitHostedService();
            services.AddScoped<BasketCheckoutConsumer>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
