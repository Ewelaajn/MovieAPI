using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using FluentAssertions;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Models;
using NUnit.Framework;

namespace MovieApiTests.Services
{
    [TestFixture]
    public partial class MovieMapperTests
    {
        [Test]
        [TestCase("FirstTitle", "FirstTitle")]
        [TestCase("SecondTitle", "SecondTitle")]
        public void StringMappingMoviePropertyStrategy_ValidTitleSupplied_ReturnsTitle
            (string value, string expectedResult)
        {
            var result = _stringStrategy.Process(value);
            result.Should().BeEquivalentTo(expectedResult);
        }
        
        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void StringMappingMoviePropertyStrategy_StringIsNullOrEmpty_ReturnsNull(string value)
        {
            var result = _stringStrategy.Process(value);
            result.Should().BeNull();
        }
        
        [Test]
        [TestCase("2000", 2000)]
        [TestCase("55", 50)]
        [TestCase("123,456", 123456)]
        public void IntegerMappingMoviePropertyStrategy_ValueIsCorrect_ReturnsValueAsInt
            (string value, int expectedResult)
        {
            var result = _integerMapping.Process(value);
            result.Should().BeEquivalentTo(expectedResult);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void IntegerMappingMoviePropertyStrategy_ValueIsNullOrEmpty_ReturnsNull(string value)
        {
            var result = _integerMapping.Process(value);
            result.Should().BeNull();
        }
        
       
        [Test]
        [TestCaseSource(nameof(StringToDateTimeStrategySource))]
        public void StringToDateTimeMappingMovieStrategy_CorrectValueSupplied_ReturnsParsedDateTime
            (string date, DateTime expectedResult)
        {
            var result = _stringToDateTimeStrategy.Process(date);
            result.Should().Be(expectedResult);
        }
        
        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void StringToDateTimeMappingMovieStrategy_DateIsNullOrEmpty_ReturnsNull(string date)
        {
            var result = _stringToDateTimeStrategy.Process(date);
            result.Should().BeNull();
        }
        
        
        [Test]
        [TestCaseSource(nameof(StringToListStrategySource))]
        public void StringToListMappingMoviePropertyStrategy_ValidStringSupplied_ReturnsListOfString
            (string list, List<String> expectedResult)
        {
            var result = _stringToListStrategy.Process(list);
            result.Should().BeEquivalentTo(expectedResult);
        }
        
        [Test]
        [TestCase("Drama")]
        [TestCase("Family")]
        public async Task MovieMapper_OnlyOneGenreSupplied_ReturnsListOfGenresWithThisOne(string genre)
        {
            var movie = Movie;
            movie.Genre = genre;
            var movieDto = await _movieMapper.MovieToDtoMapper(movie);
            var exceptedResult = new List<string> {genre};
            var result = movieDto.Genres;

            result.Should().BeEquivalentTo(exceptedResult);
        }
        
        [Test]
        [TestCase("")]
        [TestCase("    ")]
        [TestCase(null)]
        public void StringToListMappingMovieStrategy_StringIsNullOrEmpty_ReturnsNull(string list)
        {
            var result = _stringToListStrategy.Process(list);
            result.Should().BeNull();
        }
        

        //Test for Ratings

        // Test for ImdbRating

        [Test]
        [TestCaseSource(nameof(PersonParserTestCaseSource))]
        public void PersonParser_ValidPersonSupplied_ReturnsCollectionOfPerson
            (string people, IEnumerable<Person> expectedResult)
        {
            var result = _personParser.ParsePerson(people);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
