using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace MovieApi.Repositories.Interfaces
{
    public interface IDbContext
    {
        NpgsqlConnection Connection { get; }
    }
}
