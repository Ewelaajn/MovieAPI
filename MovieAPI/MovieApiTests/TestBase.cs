using System.Collections.Generic;
using System.Net;
using Autofac;
using Moq;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Mappers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using RestSharp;

namespace MovieApiTests
{
    public class TestBase
    {
        public const string MovieEndpoint = "";
        public readonly Movie TestMovie;
        public readonly List<Ratings> MovieRatings;
        public readonly IContainer Container;
        private readonly string testMovieJson;

        public TestBase()
        {
            MovieRatings = new List<Ratings>
            {
                new Ratings ("Rotten Tomatoes", "80%"),
                new Ratings ("Metacritic", "66/10")
            };

            TestMovie = new Movie
            {
                Title = "Captain America: The First Avenger",
                Year = "2011",
                Rated = "PG-13",
                Released = "22 Jul 2011",
                Runtime = "124 min",
                Genre = "Action, Adventure, Sci-Fi",
                Director = "Joe Johnston",
                Writer = "Christopher Markus (screenplay), Stephen McFeely (screenplay), Joe Simon (comic books), Jack Kirby (comic books)",
                Actors = "Chris Evans, Hayley Atwell, Sebastian Stan, Tommy Lee Jones",
                Plot = "Steve Rogers, a rejected military soldier, transforms into Captain America after taking a dose of a \"Super-Soldier serum\". But being Captain America comes at a price as he attempts to take down a war monger and a terrorist organization.",
                Language = "English, Norwegian, French",
                Country = "USA",
                Awards = "4 wins & 46 nominations.",
                Ratings = MovieRatings,
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

            testMovieJson = JsonConvert.SerializeObject(TestMovie);

            Container = BuildContainer();
        }

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MovieMapper>();

            var restClient = BuildRestClient();

            return builder.Build();
        }

        private IRestClient BuildRestClient()
        {
            var mockRestClient = new Mock<IRestClient>();


            return mockRestClient.Object;
        }

    }
}
