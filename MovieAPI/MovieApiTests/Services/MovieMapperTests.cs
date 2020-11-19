using NUnit.Framework;

namespace MovieApiTests.Services
{
    [TestFixture]
    public partial class MovieMapperTests : TestBase
    {
        /*[SetUp]
        public void SetUp()
        {
            /*_movieMapper = Container.Resolve<MovieMapper>();
            _personParser = Container.Resolve<PersonParser>();
            _integerMapping = Container.Resolve<IntegerMappingMoviePropertyStrategy>();
            _personStrategy = Container.Resolve<PersonMappingMoviePropertyStrategy>();
            _stringStrategy = Container.Resolve<StringMappingMoviePropertyStrategy>();
            _runtimeStrategy = Container.Resolve<RuntimeInMinutesMappingPropertyStrategy>();
            _stringToDateTimeStrategy = Container.Resolve<StringToDateTimeMappingPropertyStrategy>();
            _stringToListStrategy = Container.Resolve<StringToListMappingMoviePropertyStrategy>();#1#
        }

        /*private MovieMapper _movieMapper;
        private PersonParser _personParser;
        private IntegerMappingMoviePropertyStrategy _integerMapping;
        private PersonMappingMoviePropertyStrategy _personStrategy;
        private RuntimeInMinutesMappingPropertyStrategy _runtimeStrategy;
        private StringMappingMoviePropertyStrategy _stringStrategy;
        private StringToDateTimeMappingPropertyStrategy _stringToDateTimeStrategy;
        private StringToListMappingMoviePropertyStrategy _stringToListStrategy;#1#

        [Test]
        public async Task MovieMapper_ValidParametersSupplied_ReturnsMovieDto()
        {
            var movie = Movie;
            var expectedResult = MovieDto;

            /*var result = await _movieMapper.MovieToDtoMapper(movie);#1#

            /*result.Should().BeEquivalentTo(expectedResult);#1#
        }*/
    }
}