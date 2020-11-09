namespace MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies
{
    public class IntegerMappingMoviePropertyStrategy : IMappingMoviePropertyStrategy
    {
        public object Process(object property)
        {
            var value = property.ToString();

            if (int.TryParse(value, out var number))
                return number;
            return null;
        }
    }
}