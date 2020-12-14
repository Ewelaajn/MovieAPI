using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieApi.Omdb.Client;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Models;
using MovieApi.Services.Interfaces;
using MovieApi.Services.Models;

namespace MovieApi.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IOmdbClient _client;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;

        public MovieService(
            IOmdbClient client,
            IMapper mapper,
            IUserRepository userRepository,
            IMovieRepository movieRepository)
        {
            _client = client;
            _mapper = mapper;
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public async Task<List<FoundMoviesDto>> SearchMoviesByTitle(string title, int page = 1)
        {
            var movieResults = await _client.SearchVideoByTitle(title, page);
            var result = movieResults.Search
                .Select(movie => _mapper.Map<FoundMoviesDto>(movie))
                .ToList();

            return result;
        }

        public async Task<MovieDto> SingleMovieByTitle(string title)
        {
            var movie = await _client.SingleMovieByTitle(title);

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> SingleMovieByImdbId(string imdbId)
        {
            var movie = await _client.SingleMovieByImdbId(imdbId);

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> AddedMovie(string imdbId, string mail, double? rating)
        {
            var movie = await _client.SingleMovieByImdbId(imdbId);
            var movieDto = _mapper.Map<MovieDto>(movie);
            var user = _userRepository.GetUserByMail(mail);
            var dbMovie = new DbMovie()
            {
                Title = movieDto.Title,
                ReleaseDate = movieDto.Released,
                Runtime = movieDto.RuntimeInMinutes,
                ImdbRating = movieDto.ImdbRating,
                Poster = movieDto.Poster
            };

            if (rating != null)
                await _movieRepository.InsertIntoWatched(user.Id, dbMovie.Id, rating);

            await _movieRepository.InsertIntoToWatch(user.Id, dbMovie.Id);
            await _movieRepository.InsertMovieValuesIntoDb(dbMovie, movie, user.Id);

            return movieDto;
        }

        public async Task<WatchedMovieDto> UpdateRatingInWatched(string mail, string title, double rating)
        {
            var movie = await _movieRepository.UpdateRatingInWatched(mail, title, rating);

            return new WatchedMovieDto()
            {
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                Runtime = movie.Runtime,
                ImdbRating = movie.ImdbRating,
                Poster = movie.Poster,
                Rating = rating
            };
        }
    }
}