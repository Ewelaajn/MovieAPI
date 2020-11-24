using MovieApi.Middleware.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

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
