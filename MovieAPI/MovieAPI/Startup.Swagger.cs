using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MovieAPI
{
    public partial class Startup
    {
        private void ConfigureSwagger(ref IServiceCollection services)
        {
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
    }
}
