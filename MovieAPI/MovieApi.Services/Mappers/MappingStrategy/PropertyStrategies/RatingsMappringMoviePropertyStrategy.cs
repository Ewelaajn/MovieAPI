using System.Collections.Generic;
using MovieApi.Services.Models;

namespace MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies
{
    public class RatingsMappingMoviePropertyStrategy : IMappingMoviePropertyStrategy
    {
        public object Process(object property)
        {
            var ratings = new List<Ratings>();
            
            throw new System.NotImplementedException();
        }
    }
}