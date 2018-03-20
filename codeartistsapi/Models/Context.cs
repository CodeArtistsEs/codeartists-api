using Microsoft.EntityFrameworkCore;

namespace codeartistsapi.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<New> News { get; set; }

    }
}