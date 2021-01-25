using System.Threading.Tasks;
using Dapper;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Models;
using MovieApi.Repositories.Queries;
using Npgsql;

namespace MovieApi.Repositories.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IDbContext _dbContext;

        public GenreRepository(
            IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genre> InsertIntoGenre(string genre)
        {
            try
            {
                var insertedGenre = await _dbContext.Connection.QueryFirstAsync<Genre>(
                    GenreQueries.InsertIntoGenre, new {type = genre});

                return insertedGenre;
            }
            catch (PostgresException)
            {
                var dbGenre = await _dbContext.Connection.QueryFirstOrDefaultAsync<Genre>(
                    GenreQueries.GetGenreByType, new {type = genre});

                return dbGenre;
            }
        }

        public async Task<MovieGenre> InsertIntoMovieGenre(int movieId, int genreId)
        {
            var insertedMovieGenre = await _dbContext.Connection.QueryFirstAsync<MovieGenre>(
                GenreQueries.InsertIntoMovieGenre, new {movieId, genreId});

            return insertedMovieGenre;
        }
    }
}