using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CellNinja.Configurations;
using CellNinja.DependencyInjection;
using CellNinja.MovieSearch.Clients;
using CellNinja.MovieSearch.Repos;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace AwesomeApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            RegisterIoc();

            Chooser chooser = DependencyInjection.Get<Chooser>();
            await chooser.AskAsync();
        }

        private static void RegisterIoc()
        {
            DependencyInjection.RegisterSingleton<IConfiguration>(() => GetConfiguration());
            DependencyInjection.RegisterSingleton<IApiKeyConfiguration>(() => GetApiKeyConfiguration());
            DependencyInjection.Register<IClient, Client>();
            DependencyInjection.Register<IRestClient>(() => new RestClient());
            DependencyInjection.Register<IMovieRepo, MovieRepo>();
            DependencyInjection.Register<Chooser>();

            DependencyInjection.Verify();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        private static IApiKeyConfiguration GetApiKeyConfiguration()
        {
            var configurationRoot = GetConfiguration();

            var apiKeys = configurationRoot
                .GetSection("ApiKeys")
                .GetChildren()
                .ToDictionary(s => s.Key, s => s.Value);

            return new ApiKeyConfiguration(apiKeys);
        }
    }
}
