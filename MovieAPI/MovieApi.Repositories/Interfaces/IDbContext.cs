using Npgsql;

namespace MovieApi.Repositories.Interfaces
{
    public interface IDbContext
    {
        NpgsqlConnection Connection { get; }
    }
}