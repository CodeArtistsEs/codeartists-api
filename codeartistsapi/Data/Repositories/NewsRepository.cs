using System.Collections.Generic;
using System.Linq;
using codeartistsapi.Models;

namespace codeartistsapi.Data.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsContext _context;
        public NewsRepository(NewsContext context) {
            _context = context;

            if (!_context.News.Any())
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

        public IEnumerable<News> FindAll()
        {
            return _context.News.AsEnumerable();
        }
    }
}