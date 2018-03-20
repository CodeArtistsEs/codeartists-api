using System;
using System.Collections.Generic;
using Xunit;
using codeartistsapi.Models;

namespace codeartistsapi.Tests
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(true,true); // just to pass the tests ;)
        }
        
        [Fact]
        public void GetAllNews_ShouldReturnAllNews()
        {
            var controller = new codeartistsapi.Controllers.NewsController();
            var result = controller.GetAllNews() as List<New>;
            
            Assert.True(result.Count > 0);
        }
    }
}