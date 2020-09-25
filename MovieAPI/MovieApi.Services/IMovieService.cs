using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Services.Models;

namespace MovieApi.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<FoundMoviesDto>> SearchMoviesByTitle(string title, int page = 1);
        Task<MovieDto> SingleMovieByTitle(string title);
    }
}