using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MovieApi.Omdb.Client.Models;
using RestSharp;

namespace MovieApi.Omdb.Client
{
    public class OmdbClient : IOmdbClient
    {
        private readonly IRestClient _client;
        private readonly OmdbApiSettings _settings;

        public OmdbClient(
            IOptions<OmdbApiSettings> settings
        )
        {
            _settings = settings.Value;
            _client = new RestClient(_settings.BaseUrl);
            _client.Timeout = _settings.ConnectionTimeout;
        }

        public async Task<SearchResult> SearchVideoByTitle(string title, int page = 1, string type = "movie")
        {
            var request = new RestRequest(Method.GET)
                .AddQueryParameter(_settings.QueryParams.ApiKey, _settings.ApiKey)
                .AddQueryParameter(_settings.QueryParams.SearchByTitle, title)
                .AddQueryParameter(_settings.QueryParams.SearchByType, type)
                .AddQueryParameter(_settings.QueryParams.PageNumber, page.ToString())
                .AddQueryParameter(_settings.QueryParams.DataTypeToReturn, "json")
                .AddHeader("Accept", "application/json");


            var response = await _client.GetAsync<SearchResult>(request);

            return response;
        }

        public async Task<Movie> SingleMovieByTitle(string title, string type = "movie")
        {
            var request = new RestRequest(Method.GET)
                    .AddQueryParameter(_settings.QueryParams.ApiKey, _settings.ApiKey)
                    .AddQueryParameter(_settings.QueryParams.SingleMovieByTitle, title)
                    .AddQueryParameter(_settings.QueryParams.SearchByType, type)
                    .AddQueryParameter(_settings.QueryParams.DataTypeToReturn, "json")
                    .AddHeader("Accept", "application/json");

                var response = await _client.GetAsync<Movie>(request);
                return response;
           
        }
    }
}