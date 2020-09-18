using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MovieApi.Omdb.Client
{
    public class OmdbClient : IOmdbClient
    {
        // TODO: temporary variables, must be change for IOptions pattern

        public const string Url = "http://www.omdbapi.com";
        public const string UrlImg = "http://img.omdbapi.com";
        public const string ApiKey = "9bcd5eea";
        public const int Timeout = 30000;

        // TODO: register with DI, inject via ctor
        private readonly IRestClient _client;

        // TODO: Inject IOptions here
        public OmdbClient()
        {
            _client = new RestClient(Url);
            _client.Encoding = Encoding.UTF8;
            _client.Timeout = Timeout;

        }

        // TODO: add parameters that can be important
        // TODO: try to create omdb client model with data what we need 
        public async Task<object> MovieByName(string title)
        {
            var request = new RestRequest(Method.GET)
                .AddParameter(OmdbParameters.ApiKey, ApiKey)
                .AddParameter(OmdbParameters.Title, "title")
                .AddHeader("Accept", "application/json");

            var response = await _client.ExecuteGetAsync(request);

            return response.Content;
        }
    }
}
