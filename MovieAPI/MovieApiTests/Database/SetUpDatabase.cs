using MovieApiTests.Database.DbManager;
using NUnit.Framework;

namespace MovieApiTests.Database
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
