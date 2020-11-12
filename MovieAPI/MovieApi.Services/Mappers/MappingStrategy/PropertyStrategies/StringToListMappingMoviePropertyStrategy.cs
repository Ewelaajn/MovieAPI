using System.Linq;

namespace MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies
{
    public class StringToListMappingMoviePropertyStrategy : IMappingMoviePropertyStrategy
    {
        public object Process(object property)
        {
            var values = property.ToString();
            var listOfStrings = values.Split(',').Select(value => value.Trim().ToList());
            
            return listOfStrings;
        }
    }
}