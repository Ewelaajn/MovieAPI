namespace MovieApi.Services.Mappers.MappingStrategy.PropertyStrategies
{
    public class RuntimeInMinutesMappingPropertyStrategy : IMappingMoviePropertyStrategy
    {
        public object Process(object property)
        {
            var minutesInString = property.ToString().Split(' ')[0].Trim();

            if (int.TryParse(minutesInString, out var minutes)) 
                return minutes;

            return null;
        }
    }
}