using Microsoft.AspNetCore.Mvc;

namespace MovieAPI
{
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : Controller
    {
    }
}