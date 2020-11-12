using System;
using System.Threading.Tasks;

namespace MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies
{
    public class StringToDateTimeMappingPropertyStrategy : IMappingMoviePropertyStrategy
    {
        public object Process(object property)
        {
            var value = property.ToString();
            
            if (DateTime.TryParse(value, out var date))
                return Task.FromResult<DateTime?>(date);

            return null;
        }
    }
}