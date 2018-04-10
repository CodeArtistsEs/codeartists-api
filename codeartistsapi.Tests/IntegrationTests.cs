using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace codeartistsapi.Tests
{
    //https://docs.microsoft.com/en-us/aspnet/core/testing/integration-testing
    public class IntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public IntegrationTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            // Act
            var response = await _client.GetAsync("/HelloWorld");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("This is my default action...",responseString);
        }
    }
}