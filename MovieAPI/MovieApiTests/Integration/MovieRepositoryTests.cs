using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Dapper;
using FluentAssertions;
using MovieApi.Repositories.Interfaces;
using MovieApi.Repositories.Models;
using Npgsql;
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
        [TestCaseSource(nameof(DbMovieTestCaseSource))]
        public async Task InsertMovieIntoDb_ValidParametersSupplied_ReturnsAddedMovie
            (string title, DateTime? releaseDate, int? runtime, double? imdbRating)
        {

            var validInput = new DbMovie
            {
                Title = title,
                ReleaseDate = releaseDate,
                Runtime = runtime,
                ImdbRating = imdbRating
            };

            var highestCurrentMovieId = AllMovies.Max(movie => movie.Id);

            var expectedResult = new DbMovie
            {
                Id = highestCurrentMovieId + 1,
                Title = title,
                ReleaseDate = releaseDate,
                Runtime = runtime,
                ImdbRating = imdbRating
            };

            var result = await MovieRepository.InsertMovieIntoDb(validInput);
          

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task InsertMovieIntoDb_MovieAlreadyExistsInDatabase_ReturnsNull()
        {
            var existingMovie = AllMovies.ElementAt(0);
            var result = await MovieRepository.InsertMovieIntoDb(existingMovie);
            
            result.Should().BeNull();
        }

        [Test]
        [TestCase(2, 1, 7.9)]
        [TestCase(1, 3, 8.0)]
        [TestCase(3, 1, 7.1)]
        public async Task InsertIntoWatched_ValidParametersSupplied_ReturnsAddedMovie
            (int userId, int movieId, double rating)
        {
            var expectedResult = new Watched
            {
                UserId = userId,
                MovieId = movieId,
                Rating = rating
            };

            var result = await MovieRepository.InsertIntoWatched(userId, movieId, rating);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        [TestCase(7, 1, 7.9)]
        [TestCase(20, 2, 8.0)]
        [TestCase(13, 1, 7.1)]
        public async Task InsertIntoWatched_UserIdOrMovieIdDoesNotExist_ReturnsPostgresExceptionCode23503
            (int userId, int movieId, double rating)
        {
            FluentActions.Invoking(async () => await MovieRepository
           .InsertIntoWatched(userId, movieId, rating))
                .Should().Throw<PostgresException>()
                .Where(exception => int.Parse(exception.SqlState) == 23503);
        }

        [Test]
        [TestCase(null, 1, 7.9)]
        [TestCase(20, null, 8.0)]
        [TestCase(13, null, null)]
        public async Task InsertIntoWatched_OneTwoOrThreeParametersAreNull_ReturnsPostgresExceptionCode23503
            (int userId, int movieId, double rating)
        {
            FluentActions.Invoking(async () => await MovieRepository
           .InsertIntoWatched(userId, movieId, rating))
                .Should().Throw<PostgresException>()
                .Where(exception => int.Parse(exception.SqlState) == 23503);
        }
    }
}