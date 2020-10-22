using System;
using System.Collections.Generic;
using System.Text;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies
{
    public class ActorsMappingMoviePropertyStrategy : IMappingMoviePropertyStrategy<string, IEnumerable<Person>>
    {
        public IEnumerable<Person> Process(string property)
        {
            return new List<Person>();
        }
    }
}
