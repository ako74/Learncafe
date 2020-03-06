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
using MediatR;
using Learncafe.WebApi.Mapping;
using Learncafe.WebApi.Services;
using MassTransit;
using Learncafe.WebApi.Messages;
using Serilog;

namespace Learncafe.WebApi
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
            services.AddControllers();
            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(Startup));
            services.AddTransient<IMapper, Mapper>();
            services.AddTransient<IWeatherService, WeatherService>();
            services.AddTransient<IMessageBus, MessageBus>();
            
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var section = Configuration.GetSection("RabbitMq");
                    var username = section.GetValue<string>("Username");
                    var password = section.GetValue<string>("Password");
                    var hostAddress = section.GetValue<string>("Host");
                    var virtualHostAddress = section.GetValue<string>("VirtualHost");
                    var host = cfg.Host(hostAddress, virtualHostAddress, h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });

                    cfg.SetLoggerFactory(provider.GetRequiredService<ILoggerFactory>());

                    EndpointConvention.Map<ITaskToProcess>(new Uri(host.Address.ToString() + "tasks-to-process"));

                }));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

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
