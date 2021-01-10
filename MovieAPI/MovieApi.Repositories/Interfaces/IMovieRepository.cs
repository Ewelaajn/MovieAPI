using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Omdb.Client.Models;
using MovieApi.Repositories.Models;
using MovieApi.Services.Models;

namespace MovieApi.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<DbMovie> InsertMovieValuesIntoDb(DbMovie dbMovie);
        Task<Watched> InsertIntoWatched(int userId, int movieId, double? rating);
        Task<ToWatch> InsertIntoToWatch(int userId, int movieId);
        List<Task<Genre>> InsertIntoGenre(List<string> genres);
        List<Task<Director>> InsertIntoDirector(List<Person> fullNames);
        List<Task<MovieGenre>> InsertIntoMovieGenre(int movieId, List<int> genreIds);
        Task<DbMovie> GetMovieByTitle(string title);
        Task<IEnumerable<DbMovie>> GetMoviesByIds(List<int> ids);
        Task<DbMovie> UpdateRatingInWatched(string mail, string title, double rating);
        Task<IEnumerable<Watched>> GetTop50WatchedMovies();
    }
}