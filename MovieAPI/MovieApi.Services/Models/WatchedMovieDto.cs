using System;

namespace MovieApi.Services.Models
{
    public class WatchedMovieDto
    {
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Runtime { get; set; }
        public double? ImdbRating { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
    }
}