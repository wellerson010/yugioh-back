using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Configuration;
using Back.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Model.Services;
using Newtonsoft.Json.Serialization;

namespace Back
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            ConfigureDatabase();
        }

        private void ConfigureDatabase()
        {
            string urlDatabase = Configuration["Database:Url"];
            string databaseName = Configuration["Database:Name"];
            string[] urls = { urlDatabase };
            RavenService.CreateStore(urls, databaseName);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //AddScoped - São criados uma vez por solicitação
            //AddSingleton
            //AddTransient - são criados qnd solicitados

            services.AddMvc().
                AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                }).
                SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddCors(cors =>
            {
                cors.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


            services.AddApplicationsDependency();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();

         //   app.UseHttpsRedirection();

            app.UseMiddleware<MiddlewareSessionPersistance>();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseCors("CorsPolicy");
            app.UseEndpoints(endPoints=>
            {
                endPoints.MapControllers();
                //endPoints.MapControllerRoute(pattern: "default", name: "{controller=Values}/{action=Get}/{id?}");
            });
        }
    }
}
