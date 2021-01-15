using Autofac;
using Dapper;
using FluentAssertions;
using MovieApi.Repositories.Interfaces;
using NUnit.Framework;

namespace MovieApiTests.Integration.RepositoriesTests
{
    public class MovieRepositoryTests : RepositoryTest
    {
        [TestFixture]
        public class BookRepositoryTest : RepositoryTest
        {
            [SetUp]
            public void SetUp()
            {
                MovieRepository = Container.Resolve<IMovieRepository>();
            }

            // testedMethodName_testCase_expectedResult 
            [Test]
            public void DbConnection_WorksCorrectly_ReturnsData()
            {
                var query = @"SELECT 1";

                var result = DbContext.Connection.QueryFirst<int>(query);

                var expectedResult = 1;

                // NUnit
                Assert.AreEqual(expectedResult, result);

                //FluentAssertions
                result.Should().Be(expectedResult);
            }
        }
    }
}