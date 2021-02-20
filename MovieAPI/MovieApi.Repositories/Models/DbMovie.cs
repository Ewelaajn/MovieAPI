using System;

namespace MovieApi.Repositories.Models
{
    public class DbMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Runtime { get; set; }
        public double? ImdbRating { get; set; }
    }
}