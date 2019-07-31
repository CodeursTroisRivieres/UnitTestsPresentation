using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CellNinja.Configurations;
using CellNinja.MovieSearch.Clients;
using CellNinja.MovieSearch.Models;
using CellNinja.MovieSearch.Repos;
using Moq;
using RestSharp;
using Xunit;

namespace CellNinja.MovieSearch.Tests
{
    public class MovieRepoTests
    {
        private Mock<IClient> _clientMock;
        private Mock<IApiKeyConfiguration> _apiKeyConfigurationMock;

        public MovieRepoTests()
        {
            _clientMock = new Mock<IClient>();
            _clientMock
                .Setup(c => c.GetAsync<OmdbResult>(It.IsAny<IRestRequest>()))
                .Returns(Task.FromResult(new OmdbResult
                {
                    Search = new List<Movie>
                    {
                        new Movie { Title = "Result1", ImdbID = "1" }
                    }
                }));

            _apiKeyConfigurationMock = new Mock<IApiKeyConfiguration>();
            _apiKeyConfigurationMock
                .Setup(akc => akc.ApiKeys)
                .Returns(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Omdb", "DUMMY_API_KEY")
                });
        }

        [Theory]
        [InlineData("Hulk")]
        [InlineData("123")]
        [InlineData("_")]
        public async Task SearchAsync_ValidSearch_ShouldReturnListOfMovies(string query)
        {
            //Arrange
            IClient client = _clientMock.Object;
            IApiKeyConfiguration apiKeyConfiguration = _apiKeyConfigurationMock.Object;
            MovieRepo repo = new MovieRepo(client, apiKeyConfiguration);

            //Act
            var result = await repo.SearchAsync(query);

            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("     ")]
        [InlineData(null)]
        public async Task SearchAsync_Null_ShouldThrowArgumentNullException(string emptyString)
        {
            //Arrange
            IClient client = _clientMock.Object;
            IApiKeyConfiguration apiKeyConfiguration = _apiKeyConfigurationMock.Object;
            MovieRepo repo = new MovieRepo(client, apiKeyConfiguration);

            //Act
            Func<Task> action = async () => await repo.SearchAsync(emptyString);

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(action);
        }
    }
}
