using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MovieApi.Omdb.Client.Models;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Models;
using MovieApi.Repositories.Queries;
using MovieApi.Services.Models;

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

        public async Task<DbMovie> InsertMovieValuesIntoDb(DbMovie dbMovie)
        {
            var addedMovie = await _dbContext.Connection.QueryFirstOrDefaultAsync<DbMovie>(
                MovieQueries.InsertIntoMovie, new
                {
                    dbMovie.Title, 
                    dbMovie.ReleaseDate, 
                    dbMovie.Runtime, 
                    dbMovie.ImdbRating, 
                    dbMovie.Poster
                });

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

        public List<Task<Genre>> InsertIntoGenre(List<string> genres)
        {
            var insertedGenres = genres
                .Select(async genre => await _dbContext.Connection.QueryFirstAsync<Genre>(
                    MovieQueries.InsertIntoGenre, new {type = genre})).ToList();

            return insertedGenres;
        }


        public List<Task<Director>> InsertIntoDirector(List<Person> directors)
        {
            var insertedDirectors = directors
                .Select(async director => await _dbContext.Connection.QueryFirstAsync<Director>(
                    MovieQueries.InsertIntoDirector, new {director.FirstName, director.LastName})).ToList();

            return insertedDirectors;
        }


        public List<Task<MovieGenre>> InsertIntoMovieGenre(int movieId, List<int> genreIds)
        {
            var insertedMovieGenres = genreIds
                .Select(async id => await _dbContext.Connection.QueryFirstAsync<MovieGenre>(
                    MovieQueries.InsertIntoMovieGenre, new {movieId, genreId = id})).ToList();

            return insertedMovieGenres;
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