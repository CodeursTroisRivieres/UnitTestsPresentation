using System;
using System.Threading.Tasks;
using RestSharp;

namespace CellNinja.MovieSearch.Clients
{
    public interface IClient
    {
        Uri BaseUrl { get; set; }
        Task<T> GetAsync<T>(IRestRequest request) where T : new();
    }
}
