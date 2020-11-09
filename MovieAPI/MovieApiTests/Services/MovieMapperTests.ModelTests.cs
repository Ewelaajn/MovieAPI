using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using MovieApi.Services.Models;
using NUnit.Framework;

namespace MovieApiTests.Services
{
    [TestFixture]
    public partial class MovieMapperTests
    {
        // Tests for Title in returned ModelDto with the same title as string
        [Test]
        [TestCase("FirstTitle")]
        [TestCase("SecondTitle")]
        public async Task MovieMapper_ValidTitleSupplied_ReturnsTitleInMovieDto(string title)
        {
            var movie = Movie;
            movie.Title = title;
            var expectedResult = title;
            var movieDto = await _movieMapper.MovieToDtoMapper(movie);
            var result = movieDto.Title;

            result.Should().BeEquivalentTo(expectedResult);
        }

        // Test for title, when title is null or has white spaces, should return null
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public async Task MovieMapper_TitleIsNullOrEmptyString_ReturnsNullTitleInMovieDto(string title)
        {
            var movie = Movie;
            movie.Title = title;
            var movieDto = await _movieMapper.MovieToDtoMapper(movie);
            var result = movieDto.Title;

            result.Should().BeNull();
        }

        // Test for Year And Metascore property, if parses correctly, result is as expected
        [Test]
        [TestCase("2000")]
        public async Task MovieMapper_ValidYearSupplied_ReturnsYearAsInt(string year)
        {
            var movie = Movie;
            var movieDto = MovieDto;
            movie.Year = year;

            var success = int.TryParse(year, out var expectedResult);
            if (success)
                movieDto = await _movieMapper.MovieToDtoMapper(movie);
            else
                throw new Exception("Parsing is not successful.");

            var result = movieDto.Year;
            result.Should().Be(expectedResult);
        }

        // Test for year, if this property is null, has white spaces or starts with 0, returns null
        [Test]
        [TestCase("0")]
        [TestCase("")]
        [TestCase(null)]
        public async Task MovieMapper_YearIsNullEmptyOrStartsWithZero(string year)
        {
            var movie = Movie;
            movie.Year = year;
            var movieDto = await _movieMapper.MovieToDtoMapper(movie);
            var result = movieDto.Year;

            result.Should().BeNull();
        }

        // Test for Year, when there's wrong format inside (other chars than numbers) throw exception
        [Test]
        [TestCase("1a2b3c")]
        [TestCase("qwerty")]
        public void MovieMapper_YearHasWrongFormat_ReturnsExceptionWithMessage(string year)
        {
            var movie = Movie;
            movie.Year = year;

            FluentActions.Invoking(() => _movieMapper.MovieToDtoMapper(movie))
                .Should().Throw<Exception>()
                .WithMessage("Parsing year went wrong.");
        }

        [Test]
        [TestCase("2005", 2005)]
        [TestCase("2002", 2002)]
        [TestCase("25", 25)]
        public void IntegerStrategy_ValidValueSupplied_ReturnsInteger(string value, int expectedValue)
        {
            var result = _integerMapping.Process(value);
            result.Should().Be(expectedValue);
        }

        // Test for Rated property valid parameters, should return the same as string

        [Test]
        [TestCase("PG-15")]
        [TestCase("PG-23")]
        public async Task MovieMapper_ValidRatedSupplied_ReturnsRatedAsString(string rated)
        {
            var movie = Movie;
            movie.Rated = rated;
            var movieDto = await _movieMapper.MovieToDtoMapper(movie);
            var expectedResult = rated;
            var result = movieDto.Rated;

            result.Should().BeEquivalentTo(rated);
        }

        // Test for Rated when string is null or empty inside, should return null
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public async Task MovieMapper_RatedIsNullOrEmpty_ReturnsNull(string rated)
        {
            var movie = Movie;
            movie.Rated = rated;
            var movieDto = await _movieMapper.MovieToDtoMapper(movie);
            var result = movieDto.Rated;

            result.Should().BeNull();
        }

        // Test for Released, parsing from string to DateTime, should Return Date in "DD-MM-YYYY"
        [Test]
        [TestCase("11-Jul-2000")]
        public async Task MovieMapper_ValiedReleasedSupplied_ReturnsReleasedAsDateTime(string released)
        {
            var movie = Movie;
            movie.Released = released;
            var movieDto = MovieDto;

            var success = DateTime.TryParse(released, out var expectedResult);
            if (success)
                movieDto = await _movieMapper.MovieToDtoMapper(movie);
            else
                throw new Exception("Parsing is not successful.");

            var result = movieDto.Released;

            result.Should().Be(expectedResult);
        }

        //Test for Released when Parsing will be not successful, throw exception
        [Test]
        [TestCase("abcd")]
        [TestCase("Wrong Format")]
        public void MovieMapper_NoDateInReleased_ReturnsException()
        {
            var movie = Movie;

            Action act = async () => await _movieMapper.MovieToDtoMapper(movie);
            act.Should().Throw<Exception>().WithMessage("Parsing released property went wrong.");
        }

        // Test for Released when property has only white spaces or is empty, returns null
        [Test]
        [TestCase("  ")]
        [TestCase("")]
        public async Task MovieMapper_ReleasedHasWhiteSpaceOrIsEmpty_ReturnsNullInReleasedProperty(string released)
        {
            var movie = Movie;
            movie.Released = released;
            var movieDto = await _movieMapper.MovieToDtoMapper(movie);
            var result = movieDto.Released;
            result.Should().BeNull();
        }

        // Test for Genres, when there are more than 1, returns list of string with those genres
        [Test]
        public async Task MovieMapper_MoreThanOneGenre_ReturnsListOfGenres()
        {
            var movie = Movie;
            movie.Genre = "Horror, Action, Comedy";
            var movieDto = await _movieMapper.MovieToDtoMapper(movie);
            var excpectedResult = new List<string> {"Horror", "Action", "Comedy"};
            var result = movieDto.Genres;

            result.Should().BeEquivalentTo(excpectedResult);
        }

        // Test for Genres, when there's only one genre, returns list of strings with one genre
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

        // Test for Genres, when it's null, has white spaces, check if theres more than one white space 
        [Test]
        [TestCase("    ")]
        [TestCase(null)]
        public async Task MovieMapper_GenreIsNullOrHasOnlyWhiteSpaces_ReturnsNull(string genre)
        {
            var movie = Movie;
            movie.Genre = genre;
            var movieDto = await _movieMapper.MovieToDtoMapper(movie);
            var result = movieDto.Genres;

            result.Should().BeNull();
        }

        // Test for genres, when there are too many white spaces, chars after that, or there are but not points
        // Null or exception
        [Test]
        [TestCase(" Action,  Horror")]
        [TestCase("  Crime")]
        [TestCase("Crime Thriller Sci-Fi")]
        public async Task MovieMapper_GenreHasWhiteSpacesAndCharsButNoPoints_Returns(string genres)
        {
            var movie = Movie;
            movie.Genre = genres;
            var movieDto = await _movieMapper.MovieToDtoMapper(movie);
            var result = movieDto.Genres;
        }

        // Test for director, actor, writer, the same type, when there are valid parameterers, should return List of person
        // Testing on property actor, because writer and director should return the same in the same cases
        [Test]
        public async Task MovieMapper_DirectorWriterAndActorWithValidParameters_ReturnListOfPerson()
        {
            var movie = Movie;
            movie.Actors = "Dominic Jonson, Carlos Santos, Rebbeca Chambers";
            var expectedResult = new List<Person>
            {
                new Person
                {
                    FirstName = "Dominic",
                    LastName = "Jonson"
                },
                new Person
                {
                    FirstName = "Carlos",
                    LastName = "Santos"
                },
                new Person
                {
                    FirstName = "Rebbeca",
                    LastName = "Chambers"
                }
            };
            var movieDto = await _movieMapper.MovieToDtoMapper(movie);
            var result = movieDto.Actors;

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        [TestCaseSource(nameof(PersonParserTestCaseSource))]
        public void PersonParser_CorrectInput_ReturnsCollectionOfPerson
            (string people, IEnumerable<Person> expectedResult)
        {
            var result = _personParser.ParsePerson(people);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}