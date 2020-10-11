using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MovieApi.Services.Models
{
    public class FoundMoviesDto
    {
        public string Title { get; set; }

        [JsonConverter(typeof(DateNoTimeConverter))]
        public DateTime? Year { get; set; }

        public string ImdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    public class DateNoTimeConverter : IsoDateTimeConverter
    {
        public DateNoTimeConverter()
        {
            DateTimeFormat = "dd-MM-yyyy";
        }
    }
}