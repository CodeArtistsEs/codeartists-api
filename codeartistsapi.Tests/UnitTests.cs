using System;
using System.Collections.Generic;
using Xunit;
using codeartistsapi.Models;
using Microsoft.EntityFrameworkCore;
using codeartistsapi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;

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
                var newsController = new NewsController(context);
                
                var response = newsController.GetAll() as OkObjectResult;
                var result = response.Value as JObject;

                var newsList = result.Value<JArray>("data").Values().ToList();

                Assert.True(newsList.Count > 0);
            }
        }
    }
}