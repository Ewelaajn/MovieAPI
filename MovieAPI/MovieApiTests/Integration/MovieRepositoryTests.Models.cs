using System;
using System.Collections.Generic;
using MovieApi.Repositories.Models;
using NUnit.Framework;

namespace MovieApiTests.Integration
{
    public partial class MovieRepositoryTests
    {
        private IEnumerable<DbMovie> AllMovies => new List<DbMovie>
        {
            new DbMovie
            {
                Id = 1,
                Title = "The Lord of the Rings: The Return of the King",
                ReleaseDate = new DateTime(2003, 12, 17),
                Runtime = 201,
                ImdbRating = 8.9
            },
            new DbMovie
            {
                Id = 2,
                Title = "American Beauty",
                ReleaseDate = new DateTime(1999, 10, 01),
                Runtime = 122,
                ImdbRating = 8.3
            },
            new DbMovie
            {
                Id = 3,
                Title = "The Green Mile",
                ReleaseDate = new DateTime(1999, 12, 10),
                Runtime = 189,
                ImdbRating = 8.6
            },
            new DbMovie
            {
                Id = 4,
                Title = "Dragon",
                ReleaseDate = new DateTime(2011, 07, 04),
                Runtime = 98,
                ImdbRating = 7.1
            },
            new DbMovie
            {
                Id = 5,
                Title = "Hannibal",
                ReleaseDate = new DateTime(2001, 02, 09),
                Runtime = 131,
                ImdbRating = 6.8
            }
        };

        public static IEnumerable<TestCaseData> DbMovieTestCaseSource
        {
            get
            {
                yield return new TestCaseData("Angela's Ashes", new DateTime(2000, 01, 21), 145, 7.3);
                yield return new TestCaseData("The Lord of the Rings: The Return of the King", new DateTime(2003,12,17), 201, 8.9);
                yield return new TestCaseData("CustomMovie", null, null, null);
            }
        }
    }
}