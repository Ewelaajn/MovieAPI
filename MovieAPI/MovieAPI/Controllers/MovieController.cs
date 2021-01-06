using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Services.Interfaces;

namespace MovieAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    public class MovieController : ApiControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("~/search/movie_by_title/{title}")]
        public async Task<IActionResult> SearchMovieByTitle(string title, int page = 1)
        {
            var results = await _service.SearchMoviesByTitle(title, page);
            return Ok(results);
        }

        [HttpGet]
        public async Task<IActionResult> MovieByTitle(string title)
        {
            var movie = await _service.SingleMovieByTitle(title);

            return Ok(movie);
        }

        [HttpGet]
        [Route("~/search/movie_by_imdb_id/{imdbId}")]
        public async Task<IActionResult> MovieByImdbId(string imdbId)
        {
            var movie = await _service.SingleMovieByImdbId(imdbId);

            return Ok(movie);
        }

        [HttpGet]
        public async Task<IActionResult> GetTop50WatchedMovies()
        {
            var movies = await _service.GetTop50WatchedMovies();

            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(string imdbIdb, string mail, double? rating)
        {
            var movie = await _service.AddedMovie(imdbIdb, mail, rating);

            return Accepted("You have added new movie to database:", movie);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRatingInWatched(string mail, string title, double rating)
        {
            var updatedMovie = await _service.UpdateRatingInWatched(mail, title, rating);
            if (updatedMovie == null)
                return NotFound("User or Movie with those credentials does not exists in database!");
            
            return Accepted("Resource updated successfully.", updatedMovie);
        }
    }
}