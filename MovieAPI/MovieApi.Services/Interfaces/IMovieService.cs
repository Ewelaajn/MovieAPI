using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Services.Models;

namespace MovieApi.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<FoundMoviesDto>> SearchMoviesByTitle(string title, int page = 1);
        Task<MovieDto> SingleMovieByTitle(string title);
        Task<MovieDto> SingleMovieByImdbId(string imdbId);
        Task<MovieDto> AddedMovie(string imdbId, string mail, double? rating);
    }
}