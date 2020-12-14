using MovieApi.Omdb.Client.Models;
using MovieApi.Repositories.Models;
using System.Threading.Tasks;

namespace MovieApi.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<DbMovie> InsertMovieValuesIntoDb(DbMovie dbMovie, Movie movie, int userId);
        Task<Watched> InsertIntoWatched(int userId, int movieId, double? rating);
        Task<ToWatch> InsertIntoToWatch(int userId, int movieId);
        Task<DbMovie> GetMovieByTitle(string title);
        Task<DbMovie> UpdateRatingInWatched(string mail, string title, double rating);
    }
}
