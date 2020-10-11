using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MovieApi.Omdb.Client;
using MovieApi.Services;
using MovieApi.Services.Mappers;
using MovieApi.Services.Settings;

namespace MovieAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IOmdbClient, OmdbClient>();
            services.AddScoped<IMovieMapper, MovieMapper>();

            services.AddControllers();

            services.AddOptions().Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));
            services.AddOptions().Configure<OmdbApiSettings>(Configuration.GetSection("ExternalApis:OmdbApi"));

            services.AddMvcCore(options => { options.EnableEndpointRouting = false; }).AddApiExplorer()
                .AddControllersAsServices()
                .AddApiExplorer()
                .AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Movie API",
                    Version = "0.0.1",
                    Description = "Api for movie enthusiast."
                });
            });
        }

        // TODO: read about injecting IOption to this method (why to use it)
        // TODO: add swagger and endpoints routes
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

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