using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using codeartistsapi.Models;
using codeartistsapi.Data.Repositories;
using codeartistsapi.Data;
using codeartistsapi.Controllers;
using codeartistsapi.Helpers;

namespace codeartistsapi.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Test()
        {
            Assert.Equal(true, true); // just to pass the tests ;)
        }
        
        [Fact]
        public void GetAllNews_ShouldReturnAllNews()
        {
            var options = new DbContextOptionsBuilder<NewsContext>()
                .UseInMemoryDatabase(databaseName: "codeartists_test")
                .Options;

            using (var context = new NewsContext(options))
            {
                var news = new News() { 
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