using System;
using System.Collections.Generic;
using MovieApi.Services.Models;

namespace MovieApiTests.MovieModels
{
    public class TestMovieDto
    {
        public MovieDto MovieDto { get; set; }

        public TestMovieDto()
        {
            MovieDto = new MovieDto
            {
                Title = "Captain America: The First Avenger",
                Year = 2011,
                Rated = "PG-13",
                Released = new DateTime(2011, 07, 22),
                RuntimeInMinutes = 124,
                Genres = new List<string> {"Action", "Adventure", "Sci-Fi"},

                Director = new List<Person>
                {
                    new Person
                    {
                        FirstName = "Joe",
                        LastName = "Johnston"
                    }
                },

                Writers = new List<Person>
                {
                    new Person
                    {
                        FirstName = "Christopher",
                        LastName = "Markus"
                    },
                    new Person
                    {
                        FirstName = "Stephen",
                        LastName = "McFeely"
                    },
                    new Person
                    {
                        FirstName = "Joe",
                        LastName = "Simon"
                    },
                    new Person
                    {
                        FirstName = "Jack",
                        LastName = "Kirby"
                    }
                },

                Actors = new List<Person>
                {
                    new Person
                    {
                        FirstName = "Chris",
                        LastName = "Evans"
                    },
                    new Person
                    {
                        FirstName = "Hayley",
                        LastName = "Atwell"
                    },
                    new Person
                    {
                        FirstName = "Sebastian",
                        LastName = "Stan"
                    },
                    new Person
                    {
                        FirstName = "Tommy Lee",
                        LastName = "Jones"
                    }
                },

                Languages = new List<string> {"English", "Norwegian", "French"},
                Countries = new List<string> {"USA"},
                Awards = "4 wins & 46 nominations.",

                Ratings = new List<Ratings>
                {
                    new Ratings
                    {
                        Source = "Rotten Tomatoes",
                        Value = "80%"
                    },
                    new Ratings
                    {
                        Source = "Meracritic",
                        Value = "66/10"
                    }
                },

                Metascore = 66,
                ImdbRating = 6.9,
                ImdbVotes = 725377,
                ImdbId = "tt0458339",
                DVD = new DateTime(2011, 10, 25),
                Production = "Paramount Pictures"
            };
        }
    }
}