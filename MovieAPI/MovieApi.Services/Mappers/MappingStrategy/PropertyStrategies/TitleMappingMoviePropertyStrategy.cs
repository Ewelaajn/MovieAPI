using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies
{
    public class TitleMappingMoviePropertyStrategy: IMappingMoviePropertyStrategy<string, string>
    {
        public string Process(string property)
        {
            return property;
        }
    }
}
