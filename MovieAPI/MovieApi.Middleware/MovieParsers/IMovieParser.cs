using System;
using System.Collections.Generic;
using MovieApi.Services.Models;

namespace MovieApi.Middleware.MovieParsers
{
    public interface IMovieParser
    {
        List<Person> ParseStringToPerson(string people);
        int? ParseStringToInt(string value);
        DateTime? ParseStringToDateTime(string value);
        List<string> ParseStringToList(string value);
        int? ParseRuntimeToInt(string value);
    }
}