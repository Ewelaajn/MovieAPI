namespace MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies
{
    public class StringToStringMappingMoviePropertyStrategy : IMappingMoviePropertyStrategy
    {
        public object Process(object property)
        {
            return property.ToString();
        }
    }
}