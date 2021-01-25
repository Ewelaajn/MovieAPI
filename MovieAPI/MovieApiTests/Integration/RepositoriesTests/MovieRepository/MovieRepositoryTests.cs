using Autofac;
using Dapper;
using FluentAssertions;
using MovieApi.Repositories.Interfaces;
using NUnit.Framework;

namespace MovieApiTests.Integration.RepositoriesTests.MovieRepository
{
    [TestFixture]
    public partial class MovieRepositoryTests : RepositoryTest
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

        [Test]
        [TestCase]
        public void InsertIntoWatched_ValidParametersSupplied_ReturnsListOfMovies(
            int userId, int movieId, double? rating)
        {
            var result = MovieRepository.InsertIntoWatched(userId, movieId, rating);
        }
    }
}