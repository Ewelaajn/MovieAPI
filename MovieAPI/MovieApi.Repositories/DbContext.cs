using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MovieApi.Repositories.Interfaces;
using Npgsql;

namespace MovieApi.Repositories
{
    public class DbContext : IDbContext
    {
        public NpgsqlConnection Connection => new NpgsqlConnection(_databaseSettings.ConnectionString);
        private readonly DatabaseSettings _databaseSettings;
        
        public DbContext(IOptions<DatabaseSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings.Value;
        }
    }
}
