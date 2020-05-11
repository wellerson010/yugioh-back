using Back.Services;
using Microsoft.Extensions.DependencyInjection;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddApplicationsDependency(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddSingleton<IHTTPService, HTTPService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IYgoProDeckAPIService, YgoProDeckAPIService>();
            services.AddTransient<ISynchronizeService, SynchronizeService>();

            return services;
        }

    }
}
