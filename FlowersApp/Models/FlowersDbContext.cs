using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowersApp.Models
{
    public class FlowersDbContext : IdentityDbContext
    {
        public DbSet<Flower> Flowers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public FlowersDbContext(DbContextOptions<FlowersDbContext> options)
            : base(options)
        { }
    }
}
