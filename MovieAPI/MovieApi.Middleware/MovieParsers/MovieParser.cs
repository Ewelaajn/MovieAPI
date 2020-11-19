using System;
using System.Collections.Generic;
using System.Linq;
using MovieApi.Services.Models;

namespace MovieApi.Middleware.MovieParsers
{
    public partial class MovieParser : IMovieParser
    {
        public List<Person> ParseStringToPerson(string people)
            => string.IsNullOrEmpty(people) ? new List<Person>() : ParsePerson(people);


        public int? ParseStringToInt(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            return int.Parse(value.Replace(",", string.Empty));
        }

        public DateTime? ParseStringToDateTime(string value)
        {
            if (DateTime.TryParse(value, out var date))
                return date;
            return null; 
        }

        public List<string> ParseStringToList(string values)
            => values.Split(',')
                .Select(value => value.Trim())
                .ToList();
        

        public int? ParseRuntimeToInt(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            return int.Parse(value.Trim().Split(' ')[0]);
        }
    }
}