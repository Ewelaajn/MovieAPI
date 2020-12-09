using Dapper;
using MovieApi.Omdb.Client.Models;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Models;
using MovieApi.Repositories.Queries;
using System.Threading.Tasks;

namespace MovieApi.Repositories.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDbContext _dbContext;

        public MovieRepository(
            IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DbMovie> InsertMovieValuesIntoDb(DbMovie dbMovie, Movie movie, int userId)
        {
            var addedMovie = await _dbContext.Connection.QueryFirstOrDefaultAsync<DbMovie>(MovieQueries.InsertIntoMovie,
                new { dbMovie.Title, dbMovie.ReleaseDate, dbMovie.Runtime, dbMovie.ImdbRating, dbMovie.Poster });

            var director = movie.Director;

            await _dbContext.Connection.ExecuteAsync(MovieQueries.InsertIntoDirector,
                new { director });
            await _dbContext.Connection.ExecuteAsync(MovieQueries.InsertIntoMovieDirector,
                new { dbMovie.Id, director });
            await _dbContext.Connection.ExecuteAsync(MovieQueries.InsertIntoMovieGenre,
                new { dbMovie.Id, movie.Genre });

            return addedMovie;
        }

        public async Task<Watched> InsertIntoWatched(int userId, int movieId, double? rating)
        {
            return await _dbContext.Connection.QueryFirstOrDefaultAsync<Watched>(MovieQueries.InsertIntoWatched,
                new { userId, movieId, rating });
        }

        public async Task<ToWatch> InsertIntoToWatch(int userId, int movieId)
        {
            return await _dbContext.Connection.QueryFirstOrDefaultAsync<ToWatch>(MovieQueries.InsertIntoToWatch,
                new { userId, movieId });
        }
    }
}
