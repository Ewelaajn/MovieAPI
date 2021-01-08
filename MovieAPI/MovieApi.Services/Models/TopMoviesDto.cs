using System.Collections.Generic;

namespace MovieApi.Services.Models
{
    public class RankingPositionDto
    {
        public int Position { get; set; }
        public IEnumerable<TopMoviesDto> Movies { get; set; }
    }

    public class TopMoviesDto
    {
        public string Title { get; set; }
        public double Rating { get; set; }
    }
}