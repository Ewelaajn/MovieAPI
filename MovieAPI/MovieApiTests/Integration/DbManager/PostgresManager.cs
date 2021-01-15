﻿using System.IO;
using System.Linq;
using Dapper;
using Npgsql;

namespace MovieApiTests.Integration.DbManager
{
    public class PostgresManager
    {
        private readonly string _baseConnectionString;
        private readonly string _db;
        private readonly string _host;
        private readonly string _postgresConnectionString;
        private readonly string _pswd;
        private readonly string _testDatabaseConnectionString;
        private readonly string _user;
        private string _schema;

        public PostgresManager()
        {
            Settings = TestSettings.MapSettings();

            _host = Settings.DbManager.Host;
            _db = Settings.DbManager.DataBase;
            _user = Settings.DbManager.Username;
            _pswd = Settings.DbManager.Password;

            _baseConnectionString = $"Host={_host};Username={_user};Password={_pswd};";
            _postgresConnectionString = $"{_baseConnectionString};Database=postgres";
            _testDatabaseConnectionString = $"{_baseConnectionString};Database={_db}";
        }

        private TestSettings Settings { get; }

        public void CreateTestDb()
        {
            using (var connection = new NpgsqlConnection(_postgresConnectionString))
            {
                connection.Execute(PostgresManagerQueries.CreateDb,
                    new
                    {
                        host = _host,
                        database = _db,
                        user = _user,
                        password = _pswd
                    });
            }
        }

        public void DropTestDb()
        {
            using (var connection = new NpgsqlConnection(_postgresConnectionString))
            {
                connection.Execute(PostgresManagerQueries.DropDb,
                    new
                    {
                        database = _db,
                        user = _user,
                        password = _pswd
                    });
            }
        }

        private void BuildSchema()
        {
            var dbupDir = Settings.DbManager.DbupFolderName;

            var fileNames =
                Directory.EnumerateFiles(dbupDir).OrderBy(fileName => fileName).ToList();

            var queries = fileNames.Select(fileName => File.ReadAllText(fileName)).ToList();

            _schema = string.Join("\n", queries);
        }

        public void SetUpSchema()
        {
            if (string.IsNullOrEmpty(_schema))
                BuildSchema();

            using var connection = new NpgsqlConnection(_testDatabaseConnectionString);
            connection.Execute(_schema);
            /*FillDbWithTestData(connection);*/
        }

        public void ResetSchema()
        {
            if (string.IsNullOrEmpty(_schema))
                BuildSchema();

            using var connection = new NpgsqlConnection(_testDatabaseConnectionString);
            connection.Execute(PostgresManagerQueries.ResetSchema);
            connection.Execute(_schema);
            /*FillDbWithTestData(connection);*/
        }

        /*private void FillDbWithTestData(NpgsqlConnection connection)
        {
            var query = File.ReadAllText(Settings.DbManager.TestQueriesFileLocation);
            connection.Execute(query);
        }*/
    }
}