using System.Threading.Tasks;
using MovieApi.Repositories.Models;

namespace MovieApi.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre> InsertIntoGenre(string genre);
        Task<MovieGenre> InsertIntoMovieGenre(int movieId, int genreId);
    }
}