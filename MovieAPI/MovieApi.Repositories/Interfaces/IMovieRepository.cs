using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Repositories.Models;

namespace MovieApi.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<DbMovie> InsertMovieIntoDb(DbMovie dbMovie);
        Task<Watched> InsertIntoWatched(int userId, int movieId, double? rating);
        Task<ToWatch> InsertIntoToWatch(int userId, int movieId);
        Task<DbMovie> GetMovieByTitle(string title);
        Task<IEnumerable<DbMovie>> GetMoviesByIds(List<int> ids);
        Task<DbMovie> UpdateRatingInWatched(string mail, string title, double rating);
        Task<IEnumerable<Watched>> GetTop50WatchedMovies();
    }
}