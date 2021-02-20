using System;
using System.Linq;
using Autofac;
using Dapper;
using FluentAssertions;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Models;
using NUnit.Framework;

namespace MovieApiTests.Integration
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

            Assert.AreEqual(expectedResult, result);

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCaseSource(nameof(MovieRepositoryTests.DbMovieTestCaseSource))]
        public void InsertMovieIntoDb_ValidParametersSupplied_ReturnsAddedMovie
            (string title, DateTime? releaseDate, int? runtime, double? imdbRating)
        {
            var validInput = new DbMovie
            {
                Title = title,
                ReleaseDate = releaseDate,
                Runtime = runtime,
                ImdbRating = imdbRating
            };

            var highestCurrentMovieId = Enumerable.Max<DbMovie>(AllMovies, movie => movie.Id);

            var expectedResult = new DbMovie
            {
                Id = highestCurrentMovieId + 1,
                Title = title,
                ReleaseDate = releaseDate,
                Runtime = runtime,
                ImdbRating = imdbRating
            };

            var result = MovieRepository.InsertMovieIntoDb(validInput);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}