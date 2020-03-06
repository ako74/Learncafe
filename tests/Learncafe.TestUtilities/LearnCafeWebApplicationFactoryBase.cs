using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Learncafe.WebApi;

namespace Learcafe.TestUtilities
{
    public abstract class LearncafeWebApplicationFactoryBase : WebApplicationFactory<Startup>
    {
        protected abstract void ConfigureServices(IServiceCollection services);

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(ConfigureServices);
        }
    }
}