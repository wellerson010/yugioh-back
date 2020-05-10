using Microsoft.Extensions.DependencyInjection;
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

            return services;
        }
    }
}
