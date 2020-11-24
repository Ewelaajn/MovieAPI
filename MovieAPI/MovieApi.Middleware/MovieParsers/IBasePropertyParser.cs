using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Middleware.MovieParsers
{
    public interface IBasePropertyParser
    {
        string Parse(string value);
    }
}
