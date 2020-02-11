using Microsoft.EntityFrameworkCore;
using HomeServices.Data.Models;

namespace HomeServices.Data.Context
{
    public class HomeServicesDatabaseContext : DbContext
    {
        public HomeServicesDatabaseContext()
        {
        }

        public HomeServicesDatabaseContext(DbContextOptions<HomeServicesDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Services> Services { get; set; }

        public DbSet<CommonLookup> Lookup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Do nothing with this context
        }
    }
}
