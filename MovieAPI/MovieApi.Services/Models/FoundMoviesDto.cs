using System;
using Newtonsoft.Json;

namespace MovieApi.Services.Models
{
    public class FoundMoviesDto
    {
        public string Title { get; set; }

        [JsonConverter(typeof(JustDateNoTimeConverter))]
        public DateTime? Year { get; set; }

        public string ImdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}