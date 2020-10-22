using System.Collections.Generic;
using Autofac;
using Moq;
using MovieApi.Omdb.Client.Models;
using MovieApi.Services.Mappers;
using MovieApi.Services.Models;
using Newtonsoft.Json;
using RestSharp;

namespace MovieApiTests
{
    public class TestBase
    {
        public const string MovieEndpoint = "";
        public readonly IContainer Container;
        public readonly List<Ratings> MovieRatings;
        public readonly Movie TestMovie;
        private readonly string testMovieJson;

        public TestBase()
        {
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