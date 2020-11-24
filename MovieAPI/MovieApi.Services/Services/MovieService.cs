using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieApi.Omdb.Client;
using MovieApi.Services.Interfaces;
using MovieApi.Services.Models;
using Npgsql.TypeMapping;

namespace MovieApi.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IOmdbClient _client;
        private readonly IMapper _mapper;

        public MovieService(
            IOmdbClient client,
            IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FoundMoviesDto>> SearchMoviesByTitle(string title, int page = 1)
        {
            var movieResults = await _client.SearchVideoByTitle(title, page);

            return _mapper.Map<IEnumerable<FoundMoviesDto>>(movieResults);
        }

        public async Task<MovieDto> SingleMovieByTitle(string title)
        {
            var movie = await _client.SingleMovieByTitle(title);

            return _mapper.Map<MovieDto>(movie);
        }
    }
}