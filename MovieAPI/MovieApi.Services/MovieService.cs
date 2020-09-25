using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Omdb.Client;
using MovieApi.Services.Mappers;
using MovieApi.Services.Models;
using RestSharp;

namespace MovieApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IOmdbClient _client;
        private readonly IMovieMapper _mapper;

        public MovieService(IOmdbClient client, IMovieMapper mapper)
        {
            _client = client;
            _mapper = mapper;
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

        public async Task<MovieDto> SingleMovieByTitle(string title)
        {
            var movie = await _client.SingleMovieByTitle(title);

            return await _mapper.MovieToDtoMapper(movie);
        }
    }
}