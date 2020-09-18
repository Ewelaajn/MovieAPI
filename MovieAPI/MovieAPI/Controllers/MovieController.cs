using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using MovieApi.Omdb.Client;

namespace MovieAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    public class MovieController : ApiControllerBase
    {
        [HttpGet]
        [Route("~/movie_by_title/{title}")]
        public async Task<IActionResult> MovieByTitle(string title)
        {
            var omdbApi = new OmdbClient();

            var result = await omdbApi.MovieByName(title);

            return Json(result);
        }
    }
}
