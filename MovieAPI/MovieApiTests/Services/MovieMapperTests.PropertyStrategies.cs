using MovieApi.Services.Mappers.MappingStrategy.Parsers;

namespace MovieApiTests.Services
{
    public partial class MovieMapperTests
    {
        public IPersonParser PersonParser => new PersonParser();
    }
}