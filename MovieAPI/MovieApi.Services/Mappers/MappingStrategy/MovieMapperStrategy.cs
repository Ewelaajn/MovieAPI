using System;
using System.Threading.Tasks;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers.MappingStrategy
{
    public class MovieMapperStrategy : IMovieMapperStrategy
    {
        private readonly IMappingMoviePropertyStrategy _stringStrategy, _personStrategy, _integerStrategy;

        public MovieMapperStrategy(
            IMappingMoviePropertyStrategy stringStrategy,
            IMappingMoviePropertyStrategy personStrategy,
            IMappingMoviePropertyStrategy integerStrategy)
        {
            _stringStrategy = stringStrategy;
            _personStrategy = personStrategy;
            _integerStrategy = integerStrategy;
        }

        public Task<MovieDto> Process(Movie movie)
        {
            var properties = movie.GetType().GetProperties();

            foreach (var property in properties)
            {
                var name = property.Name;
                var result = MapProperty(name).Process(property.GetValue(movie));
                Console.WriteLine(result);
            }

            return Task.FromResult(new MovieDto());
        }

        private IMappingMoviePropertyStrategy MapProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Movie.Title):
                case nameof(Movie.Rated):
                case nameof(Movie.Awards):
                case nameof(Movie.ImdbId):
                case nameof(Movie.Production):
                    return _stringStrategy;
                case nameof(Movie.Actors):
                case nameof(Movie.Writer):
                case nameof(Movie.Director):
                    return _personStrategy;
                case nameof(Movie.Year):
                case nameof(Movie.Metascore):
                    return _integerStrategy;
                default:
                    return null;
            }
        }
    }
}