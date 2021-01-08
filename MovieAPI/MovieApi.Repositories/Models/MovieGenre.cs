using System.Collections.Generic;

namespace MovieApi.Repositories.Models
{
    public class MovieGenre
    {
        public int MovieId { get; set; }
        public List<string> Genres { get; set; }
    }
}