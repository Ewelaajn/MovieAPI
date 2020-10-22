using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using MovieApi.Services.Mappers;
using NUnit.Framework;

namespace MovieApiTests.Services
{
    [TestFixture]
    public partial class MovieMapperTests : TestBase
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
            var movie = Movie;
            var expectedResult = MovieDto;

            var result = await _movieMapper.MovieToDtoMapper(movie);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}