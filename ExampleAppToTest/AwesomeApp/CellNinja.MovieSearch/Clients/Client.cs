using System;
using System.Threading.Tasks;
using RestSharp;

namespace CellNinja.MovieSearch.Clients
{
    public class Client : IClient
    {
        private IRestClient _client;

        public Client(IRestClient restClient)
        {
            _client = restClient;
        }

        public Uri BaseUrl { get => _client.BaseUrl; set => _client.BaseUrl = value; }

        public Task<T> GetAsync<T>(IRestRequest request)
            where T : new()
        {
            return _client.GetAsync<T>(request);
        }
    }
}
