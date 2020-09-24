using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Omdb.Client;
using MovieApi.Services.Models;

namespace MovieApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IOmdbClient _client;

        public MovieService(IOmdbClient client)
        {
            _client = client;
        }
        
        public async Task<IEnumerable<FoundMoviesDto>> SearchMoviesByTitle(string title, int page = 1)
        {
            var movieResults = await _client.SearchVideoByTitle(title, page);
            return movieResults.Search.Select(movie => new FoundMoviesDto
            {
                Title = movie.Title,
                ImdbID = movie.ImdbID,
                Poster = movie.Poster,
                Type = movie.Type,
                Year = movie.Year
            });
        }
    }
}