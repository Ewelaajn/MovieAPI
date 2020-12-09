using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.Repositories.Models
{
    public class MovieGenre
    {
        public int MovieId { get; set; }
        public List<string> Genres { get; set; }
    }
}
