using MovieApi.Middleware.Extensions;

namespace MovieApi.Middleware.MovieParsers
{
    public class BasePropertyParser : IBasePropertyParser
    {
        public string Parse(string value)
        {
            if (value.IsNullOrNa())
                return null;
            return value;
        }
    }
}