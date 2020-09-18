using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    public class HomeController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> WelcomeText()
        {
            return Ok("Elo Mordo");
        }
    }
}
