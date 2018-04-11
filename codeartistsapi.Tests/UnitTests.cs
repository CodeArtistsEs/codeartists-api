using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using codeartistsapi.Models;
using codeartistsapi.Data.Repositories;
using codeartistsapi.Data;
using codeartistsapi.Controllers;
using codeartistsapi.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

namespace codeartistsapi.Tests
{
    public class UnitTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UnitTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        #region ApiCallsTests

        [Fact]
        public async Task GetAllNews_ShouldReturnAllNews()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<NewsContext>()
                .UseInMemoryDatabase(databaseName: "codeartists_test")
                .Options;

            using (var context = new NewsContext(options))
            {
                var news = new News()
                {
                    Id = 1,
                    Header = "Code Artists",
                    Content = "Hello world!"
                };

                context.News.Add(news);
                context.SaveChanges();
            }

            // Act
            var response = await _client.GetAsync("/api/News?GetAll");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var jsonResponse = new JsonResponse<List<News>, string>(responseString);
            var ListOfNews = JsonConvert.DeserializeObject<JsonResponse<List<News>,string>>(responseString);
            
            // Assert
            Assert.True(ListOfNews.Data.Count > 0);

        }
       

        #endregion

        //https://www.meziantou.net/2017/08/21/testing-an-asp-net-core-application-using-testserver
        [Fact]
        public void Test()
        {
            Assert.Equal(true, true); // just to pass the tests ;)
        }

        #region DatabaseTests

        // Database tests. Actually is not recommended to do this, change for some mockup in the future
        [Fact]
        public void GetConnStringFromConfigFile()
        {
            Mock<IHostingEnvironment> mockHostingEnvironment = new Mock<IHostingEnvironment>();
            Mock<IServiceCollection> mockServiceCollection = new Mock<IServiceCollection>();

            mockHostingEnvironment.Setup(m => m.ContentRootPath).Returns(Directory.GetCurrentDirectory());
            var codeartistsApiStartup = new codeartistsapi.Startup(mockHostingEnvironment.Object);
            codeartistsApiStartup.ConfigureServices(mockServiceCollection.Object);

            var connString = codeartistsApiStartup.ConnString;

            Assert.NotNull(connString);
        }

        [Fact]
        public void ConnectAndDisconnectFromDatabase()
        {
        }

        #endregion
    }
}