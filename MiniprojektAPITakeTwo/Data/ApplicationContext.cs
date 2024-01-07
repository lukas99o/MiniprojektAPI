using MiniprojektAPITakeTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniprojektAPITakeTwo.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<InterestLink> InterestLinks { get; set; }
    }
}
