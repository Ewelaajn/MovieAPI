using System.Collections.Generic;
using MovieApi.Services.Mappers.MappingStrategy.Parsers;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies
{
    public class PersonMappingMoviePropertyStrategy : IMappingMoviePropertyStrategy
    {
        private readonly IPersonParser _personParser;

        public PersonMappingMoviePropertyStrategy(IPersonParser personParser)
        {
            _personParser = personParser;
        }

        public object Process(object property)
        {
            var value = property.ToString();

            if (string.IsNullOrWhiteSpace(value))
                return new List<Person>();

            return _personParser.ParsePerson(value);
        }
    }
}