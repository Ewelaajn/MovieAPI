using System;
using System.Collections.Generic;
using FluentAssertions;
using MovieApi.Services.Models;
using NUnit.Framework;

namespace MovieApiTests.Services
{
    [TestFixture]
    public partial class MovieMapperTests
    {
        [Test]
        public void Test()
        {
            var movie = Movie;
            var expectedResult = MovieDto;
            var result = _mapper.Map<MovieDto>(movie);
            result.Should().BeEquivalentTo(expectedResult);
        }

        // Test for all properties which are strings in normal and dto model, checked on property "title"
        // Contains: Title, Rated, Awards, ImdbId, Production
        [Test]
        [TestCase("FirstTitle", "FirstTitle")]
        [TestCase("SecondTitle", "SecondTitle")]
        public void MovieMapperStringToString_ValidParametersSupplied_ReturnsTheSameString
            (string value, string expectedResult)
        {
            var movie = Movie;
            movie.Title = value;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.Title;

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void AutoMapperMovieStringToString_StringIsNullOrEmpty_ReturnsNull(string value)
        {
            var movie = Movie;
            movie.Title = value;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.Title;

            result.Should().BeNull();
        }

        // Test for all properties which are strings and parse to integer, checked on property "year"
        // Contains: Year, Metascore, ImdbVotes

        [Test]
        [TestCase("2000", 2000)]
        [TestCase("55", 55)]
        [TestCase("123,456", 123456)]
        public void AutoMapperParseStringToInt_ValueIsCorrect_ReturnsValueAsInt
            (string value, int expectedResult)
        {
            var movie = Movie;
            movie.Year = value;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.Year;

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void AutoMapperMovieStringToInteger_ValueIsNullOrEmpty_ReturnsNull(string value)
        {
            var movie = Movie;
            movie.Year = value;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.Year;

            result.Should().BeNull();
        }

        // Test for all properties which are strings and parse to DateTime, checked on property "Released"
        // Contains: Released, DVD
        [Test]
        [TestCaseSource(nameof(StringToDateTimeTestCaseSource))]
        public void AutoMapperMovieStringToDateTime_CorrectValueSupplied_ReturnsParsedDateTime
            (string date, DateTime expectedResult)
        {
            var movie = Movie;
            movie.Released = date;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.Released;

            result.Should().Be(expectedResult);
        }

        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void AutoMapperMovieStringToDateTime_DateIsNullOrEmpty_ReturnsNull(string date)
        {
            var movie = Movie;
            movie.Released = date;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.Released;

            result.Should().BeNull();
        }

        // Test for all properties which are string and parse to list of strings, checked on property "Genres"
        // Contains: Genres, Languages, Countries
        [Test]
        [TestCaseSource(nameof(StringToListTestCaseSource))]
        public void AutoMapperMovieStringToList_ValidStringSupplied_ReturnsListOfString
            (string list, List<string> expectedResult)
        {
            var movie = Movie;
            movie.Genre = list;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.Genres;

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        [TestCase("")]
        [TestCase("    ")]
        [TestCase(null)]
        public void StringToListMappingMovieStrategy_StringIsNullOrEmpty_ReturnsNull(string list)
        {
            var movie = Movie;
            movie.Genre = list;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.Genres;
            var expectedResult = new List<string>();

            result.Should().BeEquivalentTo(expectedResult);
        }

        // Test for RunTime Parser
        [Test]
        [TestCase("150 min", 150)]
        [TestCase("90 min", 90)]
        [TestCase("100 min", 100)]
        public void AutoMapperMovieStringRunTimeToInt_ValidStringSupplied_ReturnsMinutesAsInt
            (string value, int? runtime)
        {
            var movie = Movie;
            movie.Runtime = value;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.RuntimeInMinutes;

            result.Should().Be(runtime);
        }

        [Test]
        [TestCase(" ")]
        [TestCase("")]
        [TestCase(null)]
        public void AutoMapperMovieStringRunTimeToInt_StringIsNullOrEmpty_ReturnsNull
            (string value)
        {
            var movie = Movie;
            movie.Runtime = value;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.RuntimeInMinutes;

            result.Should().BeNull();
        }

        // Test for all properties which are string and parse to list of person, checked on property "actor"
        // Contains: Actor, Writer, Director
        [Test]
        [TestCaseSource(nameof(StringToPersonTestCaseSource))]
        public void AutoMapperMovieStringToListOfPerson_ValidStringSupplied_ReturnsListOfPerson
            (string value, List<Person> expectedResult)
        {
            var movie = Movie;
            movie.Actors = value;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.Actors;

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void AutoMapperStringToListOfPerson_StringIsNullOrEmpty_ReturnsEmptyList(string value)
        {
            var movie = Movie;
            movie.Actors = value;
            var movieDto = _mapper.Map<MovieDto>(movie);
            var result = movieDto.Actors;
            var expectedResult = new List<Person>();

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}