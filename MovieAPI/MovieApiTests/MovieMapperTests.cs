using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using MovieApi.Services.Mappers;
using MovieApiTests.MovieModels;
using NUnit.Framework;

namespace MovieApiTests
{
    [TestFixture]
    public class MovieMapperTests : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            _movieMapper = Container.Resolve<MovieMapper>();
        }

        private MovieMapper _movieMapper;

        [Test]
        public async Task MovieMapper_ValidParametersSupplied_ReturnsMovieDto()
        {
            var movie = new TestMovie().Movie;
            var expectedResult = new TestMovieDto().MovieDto;

            var result = await _movieMapper.MovieToDtoMapper(movie);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}