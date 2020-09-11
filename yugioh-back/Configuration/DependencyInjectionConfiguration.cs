using Back.Services;
using Microsoft.Extensions.DependencyInjection;
using Model.Interfaces.Repositories;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Back.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        private static void AddMapper()
        {

        }

        public static IServiceCollection AddApplicationsDependency(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddSingleton<IHTTPService, HTTPService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IYgoProDeckAPIService, YgoProDeckAPIService>();
            services.AddTransient<ISynchronizeService, SynchronizeService>();

            services.AddAutoMapper(typeof(Startup));

            return services;
        }

    }
}
