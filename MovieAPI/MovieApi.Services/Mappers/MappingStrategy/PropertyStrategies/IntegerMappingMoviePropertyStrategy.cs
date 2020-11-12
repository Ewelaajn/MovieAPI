namespace MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies
{
    public class IntegerMappingMoviePropertyStrategy : IMappingMoviePropertyStrategy
    {
        public object Process(object property)
        {
            var value = property.ToString().Replace(",", string.Empty);

            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            int.TryParse(value, out var number);
            return number;
        }
    }
}