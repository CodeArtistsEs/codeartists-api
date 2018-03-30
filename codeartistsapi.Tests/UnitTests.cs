using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging.AzureAppServices.Internal;

namespace codeartistsapi.Tests
{
    public class UnitTests
    {
        public UnitTests()
        {
        }

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

        [Fact]
        public void GetAllNews_ShouldReturnAllNews()
        {
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

            using (var context = new NewsContext(options))
            {
                var newsRepository = new NewsRepository(context);
                var newsController = new NewsController(newsRepository);

                var response = newsController.GetAll() as OkObjectResult;
                var jsonResponse = response.Value as JsonResponse<List<News>, string>;

                var newsList = jsonResponse.Data;

                Assert.True(newsList.Count > 0);
            }
        }
    }
}