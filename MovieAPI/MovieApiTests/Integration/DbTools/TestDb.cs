using MovieApi.Repositories.Interfaces;
using Npgsql;

namespace MovieApiTests.Integration.DbTools
{
    public class TestDb : IDbContext
    {
        public TestDb()
        {
            Settings = TestSettings.MapSettings();
        }

        private TestSettings Settings { get; }
        public NpgsqlConnection Connection => new NpgsqlConnection(Settings.DbSettings.ConnectionString);
    }
}