using Microsoft.EntityFrameworkCore;
using codeartistsapi.Models;

namespace codeartistsapi.Data
{
    public class NewsContext: DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; }
    }
}