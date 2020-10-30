﻿using System;
using System.Collections.Generic;
using System.Text;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Models;

namespace MovieApiTests.Services
{
    public partial class MovieMapperTests
    {
        public Movie Movie => new Movie
        {
            Title = "Captain America: The First Avenger",
            Year = "2011",
            Rated = "PG-13",
            Released = "22 Jul 2011",
            Runtime = "124 min",
            Genre = "Action, Adventure, Sci-Fi",
            Director = "Joe Johnston",
            Writer =
                "Christopher Markus (screenplay), Stephen McFeely (screenplay), Joe Simon (comic books), Jack Kirby (comic books)",
            Actors = "Chris Evans, Hayley Atwell, Sebastian Stan, Tommy Lee Jones",
            Plot =
                "Steve Rogers, a rejected military soldier, transforms into Captain America after taking a dose of a \"Super-Soldier serum\". But being Captain America comes at a price as he attempts to take down a war monger and a terrorist organization.",
            Language = "English, Norwegian, French",
            Country = "USA",
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
                    Source = "Metacritic",
                    Value = "66/10"
                }
            },

            Metascore = "66",
            ImdbRating = 6.9,
            ImdbVotes = "725,377",
            ImdbId = "tt0458339",
            Type = "movie",
            DVD = "25 Oct 2011",
            BoxOffice = "$176,636,816",
            Production = "Paramount Pictures",
            Website = "N/A",
            Response = "True"
        };

        public MovieDto MovieDto => new MovieDto
        {
            Title = "Captain America: The First Avenger",
            Year = 2011,
            Rated = "PG-13",
            Released = new DateTime(2011, 07, 22),
            RuntimeInMinutes = 124,
            Genres = new List<string> { "Action", "Adventure", "Sci-Fi" },

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

            Languages = new List<string> { "English", "Norwegian", "French" },
            Countries = new List<string> { "USA" },
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
                    Source = "Metacritic",
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