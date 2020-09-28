using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using MovieApi.Services.Mappers;
using MovieApiTests;
using NUnit.Framework;

namespace MovieApiTests
{
    [TestFixture]

    public class MovieMapperTests : TestBase
    {
        private MovieMapper _movieMapper;

        [SetUp]
        public void SetUp()
        {
            _movieMapper = Container.Resolve<MovieMapper>();
        }

        [Test]
        public async Task ParseRuntime_Works_ReturnsRuntimeParsedOnInt()
        {
            var expectedResult = 124;

            var result = await _movieMapper.ParseRuntime(TestMovie.Runtime);

            result.Should().Be(expectedResult);
        }

        [Test]
        public async Task ParseRuntime_ParameterIsNull_ReturnsNull()
        {
            var runtime = "N/A";

            var result = await _movieMapper.ParseRuntime(runtime);

            result.Should().BeNull();
        }
    }
}
