using Microsoft.EntityFrameworkCore;

namespace FlowersApp.Models
{
    public class FlowersDbContext : DbContext
    {
        public FlowersDbContext(DbContextOptions<FlowersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
