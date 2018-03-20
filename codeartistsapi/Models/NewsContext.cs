using Microsoft.EntityFrameworkCore;

namespace codeartistsapi.Models
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