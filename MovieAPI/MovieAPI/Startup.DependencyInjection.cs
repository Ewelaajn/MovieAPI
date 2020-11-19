using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
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
        private void RegisterServices(ref IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IOmdbClient, OmdbClient>();
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMovieParser, MovieParser>();
            services.AddAutoMapper(typeof(MovieProfile));
        }

        private void RegisterOptions(ref IServiceCollection services)
        {
            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));
            services.Configure<OmdbApiSettings>(Configuration.GetSection("ExternalApis:OmdbApi"));
            services.Configure<DatabaseSettings>(Configuration.GetSection("Database"));
        }

        private void RegisterMvc(ref IServiceCollection services)
        {
            services.AddMvcCore(options => { options.EnableEndpointRouting = false; }).AddApiExplorer()
                .AddControllersAsServices()
                .AddApiExplorer()
                .AddNewtonsoftJson();

            services.AddControllers();
        }
    }
}