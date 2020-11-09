namespace MovieApi.Services.Mappers.MappingStrategy
{
    public interface IMappingMoviePropertyStrategy
    {
        object Process(object property);
    }
}