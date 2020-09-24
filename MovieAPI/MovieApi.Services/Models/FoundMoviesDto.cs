using System;

namespace MovieApi.Services.Models
{
    public class FoundMoviesDto
    {
        public string Title { get; set; }
        public DateTime? Year { get; set; }
        public string ImdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}