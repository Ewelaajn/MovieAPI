using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers.MappingStrategy
{
    public class MovieMapperStrategy: IMovieMapperStrategy
    {
        private readonly IDictionary<string, object> _propertiesMappingStrategy;
        public MovieMapperStrategy()
        {
            _propertiesMappingStrategy = new Dictionary<string, object>
            {
                {"Title", new TitleMappingMoviePropertyStrategy()},
                {"Actors", new ActorsMappingMoviePropertyStrategy()}
            };
        }

        public Task<MovieDto> Process(Movie movie)
        {
            var movieProperties = movie.GetType().GetProperties();

            foreach (var propertyInfo in movieProperties)
            {
                string propertyName = propertyInfo.Name;
            }

            return Task.FromResult(new MovieDto());
        }
    }
}
