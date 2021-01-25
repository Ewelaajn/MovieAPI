using System.Threading.Tasks;
using MovieApi.Repositories.Models;

namespace MovieApi.Repositories.Interfaces
{
    public interface IDirectorRepository
    {
        Task<Director> InsertIntoDirector(string firstName, string lastName);
        Task<MovieDirector> InsertIntoMovieDirector(int movieId, int directorId);
    }
}