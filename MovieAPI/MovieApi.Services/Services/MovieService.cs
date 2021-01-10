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
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;

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
            var user = await _userRepository.GetUserByMail(mail);
            
            var dbMovie = new DbMovie
            {
                Title = movieDto.Title,
                ReleaseDate = movieDto.Released,
                Runtime = movieDto.RuntimeInMinutes,
                ImdbRating = movieDto.ImdbRating,
                Poster = movieDto.Poster
            };

            var insertedMovie = await _movieRepository.InsertMovieValuesIntoDb(dbMovie);

            if (rating != null)
                await _movieRepository.InsertIntoWatched(user.Id, insertedMovie.Id, rating);

            await _movieRepository.InsertIntoToWatch(user.Id, insertedMovie.Id);
            var director = _movieRepository.InsertIntoDirector(movieDto.Director);
            
            var genres = _movieRepository.InsertIntoGenre(movieDto.Genres);
            var genresIds = genres.Select(genre => genre.Id).ToList();

            _movieRepository.InsertIntoMovieGenre(insertedMovie.Id, genresIds);

            return movieDto;
        }

        public async Task<WatchedMovieDto> UpdateRatingInWatched(string mail, string title, double rating)
        {
            var movie = await _movieRepository.UpdateRatingInWatched(mail, title, rating);

            return new WatchedMovieDto
            {
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                Runtime = movie.Runtime,
                ImdbRating = movie.ImdbRating,
                Poster = movie.Poster,
                Rating = rating
            };
        }

        public async Task<IEnumerable<RankingPositionDto>> GetTop50WatchedMovies()
        {
            var watchedMovies = await _movieRepository.GetTop50WatchedMovies();
            var listOfWatchedMovies = watchedMovies.ToList();
            var moviesIds = listOfWatchedMovies.Select(movie => movie.MovieId).ToList();
            var movies = await _movieRepository.GetMoviesByIds(moviesIds);

            var top50 = listOfWatchedMovies
                .Select(movie => new TopMoviesDto
                {
                    Title = movies.Single(m => m.Id == movie.MovieId).Title,
                    Rating = movie.Rating
                })
                .GroupBy(topMovie => topMovie.Rating)
                .OrderByDescending(topMovies => topMovies.Key)
                .Select((top, index) => new RankingPositionDto
                {
                    Position = index + 1,
                    Movies = top.Select(mov => mov)
                })
                .ToList();

            return top50;
        }
    }
}