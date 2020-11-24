using AutoMapper;
using MovieApi.Middleware.AutoMapper;
using NUnit.Framework;

namespace MovieApiTests.Services
{
    [TestFixture]
    public partial class MovieMapperTests : TestBase
    {
        private IMapper _mapper;
        [SetUp]
        public void SetUp()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MovieProfile>());
            _mapper = config.CreateMapper();
        }
    }
}