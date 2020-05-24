using Microsoft.EntityFrameworkCore;
using Sample.IoC.Domain.Entities;

namespace Sample.IoC.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sample.IoC.Domain.Entities.Movie> Movie { get; set; }

    }
}
