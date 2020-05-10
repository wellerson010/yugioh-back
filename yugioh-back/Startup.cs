using Back.Configuration;
using Back.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Back
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            configuration.ConfigureDatabase();
        }

        public void ConfigureServices(IServiceCollection services)
        {
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
            app.UseHttpsRedirection();
            app.UseMiddleware<MiddlewareSessionPersistance>();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endPoints=>
            {
                endPoints.MapControllers();
            });
        }
    }
}
