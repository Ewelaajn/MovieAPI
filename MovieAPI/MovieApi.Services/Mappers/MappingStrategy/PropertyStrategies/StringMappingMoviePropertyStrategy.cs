namespace MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies
{
    public class StringMappingMoviePropertyStrategy : IMappingMoviePropertyStrategy
    {
        public object Process(object property)
        {
            return property.ToString();
        }
    }
}