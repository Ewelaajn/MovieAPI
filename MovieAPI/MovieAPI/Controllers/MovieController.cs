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
    }
}