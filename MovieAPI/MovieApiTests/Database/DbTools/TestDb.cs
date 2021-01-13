using Npgsql;

namespace MovieApiTests.Database.DbTools
{
    public class TestDb
    {
        public TestDb()
        {
            Settings = TestSettings.MapSettings();
        }

        private TestSettings Settings { get; }
        public NpgsqlConnection Connection => new NpgsqlConnection(Settings.DbSettings.ConnectionString);
    }
}
