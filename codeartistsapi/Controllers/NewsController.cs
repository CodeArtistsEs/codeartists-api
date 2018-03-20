using System.Collections.Generic;
using System.Linq;
using codeartistsapi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace codeartistsapi.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly NewsContext _context;

        public NewsController(NewsContext context)
        {
            _context = context;

            if (_context.News.Count() == 0)
            {
                var news = new News() { 
                    Id = 1,
                    Header = "Code Artists",
                    Content = "Hello world!"
                };

                _context.News.Add(news);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var newsList = _context.News.ToList();

            var response = new JObject(
                new JProperty("ok", true),
                new JProperty("data", new JArray(
                    from n in newsList
                    select new JObject(
                        new JProperty("id", n.Id),
                        new JProperty("header", n.Header),
                        new JProperty("content", n.Content)
                    )
                ))
            );

            return Ok(response);
        }
    }
}