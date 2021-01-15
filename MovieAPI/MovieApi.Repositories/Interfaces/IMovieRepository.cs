using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Repositories.Models;

namespace MovieApi.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<DbMovie> InsertMovieValuesIntoDb(DbMovie dbMovie);
        Task<Watched> InsertIntoWatched(int userId, int movieId, double? rating);
        Task<ToWatch> InsertIntoToWatch(int userId, int movieId);
        Task<Genre> InsertIntoGenre(string genre);
        Task<Director> InsertIntoDirector(string firstName, string lastName);
        Task<MovieGenre> InsertIntoMovieGenre(int movieId, int genreId);
        Task<DbMovie> GetMovieByTitle(string title);
        Task<IEnumerable<DbMovie>> GetMoviesByIds(List<int> ids);
        Task<DbMovie> UpdateRatingInWatched(string mail, string title, double rating);
        Task<IEnumerable<Watched>> GetTop50WatchedMovies();
    }
}