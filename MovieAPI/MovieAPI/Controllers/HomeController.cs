using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{
    // TODO: inject service and all other necessary objects
    // TODO: create repository, design data base/dbup scripts and models for service 
    // TODO: configure postgres database
    [Produces(MediaTypeNames.Application.Json)]
    public class HomeController : ApiControllerBase
    {
        // TODO: refactor controller to redirect to swagger 
        [HttpGet]
        public async Task<IActionResult> WelcomeText()
        {
            return Ok("Elo Mordo");
        }
    }
}
