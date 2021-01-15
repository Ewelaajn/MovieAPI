﻿using MovieApiTests.Integration.DbManager;
using NUnit.Framework;

namespace MovieApiTests.Integration
{
    [SetUpFixture]
    public class SetUpDatabase
    {
        private readonly PostgresManager _postgresManager;

        public SetUpDatabase()
        {
            _postgresManager = new PostgresManager();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _postgresManager.CreateTestDb();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _postgresManager.DropTestDb();
        }
    }
}