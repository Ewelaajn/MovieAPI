using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MovieApi.Omdb.Client.Models;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Models;
using MovieApi.Repositories.Queries;

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
                new {dbMovie.Title, dbMovie.ReleaseDate, dbMovie.Runtime, dbMovie.ImdbRating, dbMovie.Poster});

            var director = movie.Director;

            await _dbContext.Connection.ExecuteAsync(MovieQueries.InsertIntoDirector,
                new {fullname = director});
            await _dbContext.Connection.ExecuteAsync(MovieQueries.InsertIntoMovieDirector,
                new {dbMovie.Id, director});
            await _dbContext.Connection.ExecuteAsync(MovieQueries.InsertIntoMovieGenre,
                new {dbMovie.Id, movie.Genre});

            return addedMovie;
        }

        public async Task<Watched> InsertIntoWatched(int userId, int movieId, double? rating)
        {
            return await _dbContext.Connection.QueryFirstOrDefaultAsync<Watched>(MovieQueries.InsertIntoWatched,
                new {userId, movieId, rating});
        }

        public async Task<ToWatch> InsertIntoToWatch(int userId, int movieId)
        {
            return await _dbContext.Connection.QueryFirstOrDefaultAsync<ToWatch>(MovieQueries.InsertIntoToWatch,
                new {userId, movieId});
        }

        public async Task<DbMovie> GetMovieByTitle(string title)
        {
            return await _dbContext.Connection.QueryFirstOrDefaultAsync<DbMovie>(
                MovieQueries.GetMovieByTitle, new {title});
        }

        public async Task<IEnumerable<DbMovie>> GetMoviesByIds(List<int> ids)
        {
            var movies = await _dbContext.Connection.QueryAsync<DbMovie>(
                MovieQueries.GetMoviesByIds, new {ids});

            return movies;
        }

        public async Task<DbMovie> UpdateRatingInWatched(string mail, string title, double rating)
        {
            var movie = await _dbContext.Connection.QueryFirstOrDefaultAsync<DbMovie>(
                MovieQueries.GetMovieByTitle, new {title});
            var user = await _dbContext.Connection.QueryFirstOrDefaultAsync<User>(
                UserQueries.GetUserByMail, new {mail});

            if (await _dbContext.Connection.QueryFirstOrDefaultAsync<bool>(
                MovieQueries.CheckIfMovieIsInWatchedTable, new {title}))
                await _dbContext.Connection.ExecuteAsync(
                    MovieQueries.ChangeRating, new {title, rating});
            else
                await _dbContext.Connection.ExecuteAsync(
                    MovieQueries.InsertIntoWatched, new {userId = user.Id, movieId = movie.Id, rating});

            return new DbMovie
            {
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                Runtime = movie.Runtime,
                ImdbRating = movie.ImdbRating,
                Poster = movie.Poster
            };
        }

        public async Task<IEnumerable<Watched>> GetTop50WatchedMovies()
        {
            var movies = await _dbContext.Connection.QueryAsync<Watched>(MovieQueries.GetTop50WithTies);

            return movies;
        }
    }
}