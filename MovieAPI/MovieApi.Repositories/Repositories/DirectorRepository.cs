using System.Threading.Tasks;
using Dapper;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Models;
using MovieApi.Repositories.Queries;
using Npgsql;

namespace MovieApi.Repositories.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly IDbContext _dbContext;

        public DirectorRepository(
            IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Director> InsertIntoDirector(string firstName, string lastName)
        {
            try
            {
                var insertedDirector = await _dbContext.Connection.QueryFirstAsync<Director>(
                    DirectorQueries.InsertIntoDirector, new {firstName, lastName});

                return insertedDirector;
            }
            catch (PostgresException)
            {
                var dbDirector = await _dbContext.Connection.QueryFirstOrDefaultAsync<Director>(
                    DirectorQueries.GetDirectorByFullName, new {firstName, lastName});

                return dbDirector;
            }
        }

        public async Task<MovieDirector> InsertIntoMovieDirector(int movieId, int directorId)
        {
            var insertedMovieDirector = await _dbContext.Connection.QueryFirstAsync<MovieDirector>(
                DirectorQueries.InsertIntoMovieDirector, new {movieId, directorId});

            return insertedMovieDirector;
        }
    }
}