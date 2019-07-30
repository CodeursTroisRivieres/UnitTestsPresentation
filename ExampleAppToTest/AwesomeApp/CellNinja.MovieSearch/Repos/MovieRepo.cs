using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CellNinja.Configurations;
using CellNinja.MovieSearch.Models;
using RestSharp;

namespace CellNinja.MovieSearch.Repos
{
    public class MovieRepo : IMovieRepo
    {
        private const string OmdbApiKeyConfigurationName = "Omdb";
        private const string ApiKeyQueryParameterName = "apikey";
        private const string SearchQueryParameterName = "s";
        private string _apiKey;

        public MovieRepo(IRestClient client, IApiKeyConfiguration apiKeyConfiguration)
        {
            Client = client;
            Client.BaseUrl = new Uri("http://www.omdbapi.com/");

            _apiKey = apiKeyConfiguration.ApiKeys
                .Where(kv => kv.Key == OmdbApiKeyConfigurationName)
                .Select(kv => kv.Value)
                .First();
        }

        private IRestClient Client { get; }

        public async Task<IEnumerable<Movie>> SearchAsync(string search)
        {
            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json
            };

            request.AddQueryParameter(ApiKeyQueryParameterName, _apiKey);
            request.AddQueryParameter(SearchQueryParameterName, search);

            var omdbResult = await Client.GetAsync<OmdbResult>(request);
            return omdbResult?.Search;
        }
    }
}
