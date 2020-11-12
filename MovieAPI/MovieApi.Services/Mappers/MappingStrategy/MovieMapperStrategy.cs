using System;
using System.Threading.Tasks;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Mappers.MappingStrategy.Parsers;
using MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers.MappingStrategy
{
    public class MovieMapperStrategy : IMovieMapperStrategy
    {
        private readonly IPersonParser _personParser;
        private readonly IMappingMoviePropertyStrategy _stringStrategy, _personStrategy, _integerStrategy,
            _dateTimeStrategy, _runtimeInMinutesStrategy, _stringToListStrategy;

        public MovieMapperStrategy()
        {
            _stringStrategy = new StringMappingMoviePropertyStrategy();
            _personStrategy = new PersonMappingMoviePropertyStrategy(_personParser);
            _integerStrategy = new IntegerMappingMoviePropertyStrategy();
            _dateTimeStrategy = new StringToDateTimeMappingPropertyStrategy();
            _runtimeInMinutesStrategy = new RuntimeInMinutesMappingPropertyStrategy();
            _stringToListStrategy = new StringToListMappingMoviePropertyStrategy();
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
                case nameof(Movie.ImdbVotes):
                    return _integerStrategy;
                
                case nameof(Movie.Released):
                case nameof(Movie.DVD):
                    return _dateTimeStrategy;
                
                case nameof(Movie.Runtime):
                    return _runtimeInMinutesStrategy;
                
                case nameof(Movie.Genre):
                case nameof(Movie.Country):
                case nameof(Movie.Language):
                    return _stringToListStrategy;
                
                default:
                    return null;
            }
        }
    }
}