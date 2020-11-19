using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MovieApi.Middleware.AutoMapper;
using MovieApi.Middleware.MovieParsers;
using MovieApi.Omdb.Client;
using MovieApi.Repositories;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Repositories;
using MovieApi.Services.Interfaces;
using MovieApi.Services.Services;
using MovieApi.Services.Settings;

namespace MovieAPI
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            RegisterServices(ref services);

            RegisterOptions(ref services);

            RegisterMvc(ref services);

            ConfigureSwagger(ref services);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}