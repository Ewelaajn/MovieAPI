namespace MovieApi.Middleware.MovieParsers
{
    public interface IBasePropertyParser
    {
        string Parse(string value);
    }
}