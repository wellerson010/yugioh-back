using Microsoft.Extensions.Configuration;
using Model.Services;

namespace Back.Configuration
{
    public static class DatabaseConfiguration
    {
        public static IConfiguration ConfigureDatabase(this IConfiguration configuration)
        {
            string urlDatabase = configuration["Database:Url"];
            string databaseName = configuration["Database:Name"];
            string[] urls = { urlDatabase };
            RavenService.CreateStore(urls, databaseName);

            return configuration;
        }
    }
}
