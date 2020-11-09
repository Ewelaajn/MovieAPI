using Microsoft.Extensions.Options;
using MovieApi.Repositories.Interfaces;
using Npgsql;

namespace MovieApi.Repositories
{
    public class DbContext : IDbContext
    {
        private readonly DatabaseSettings _databaseSettings;

        public DbContext(IOptions<DatabaseSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings.Value;
        }

        public NpgsqlConnection Connection => new NpgsqlConnection(_databaseSettings.ConnectionString);
    }
}