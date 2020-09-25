using System;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.Extensions.Options;
using MovieApi.Omdb.Client.Models;
using RestSharp;

namespace MovieApi.Omdb.Client
{
    public class OmdbClient : IOmdbClient
    {
        // TODO: temporary variables, must be change for IOptions pattern


        private readonly OmdbApiSettings _settings;
        private readonly IRestClient _client;

        // TODO: Inject IOptions here
        public OmdbClient(
            IOptions<OmdbApiSettings> settings
            )
        {
            _settings = settings.Value;
            _client = new RestClient(_settings.BaseUrl);
            _client.Timeout = _settings.ConnectionTimeout;
        }

        // TODO: add parameters that can be important
        // TODO: try to create omdb client model with data what we need 
        public async Task<SearchResult> SearchVideoByTitle(string title, int page=1, string type="movie")
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