using FlowersApp.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowersApp.Models
{
    public class FlowersDbContext : IdentityDbContext
    {
        public DbSet<Flower> Flowers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<FlowerUserPlants> FlowerUserPlants { get; set; }

        public FlowersDbContext(DbContextOptions<FlowersDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FlowerUserPlants>()
                .HasIndex(f => new { f.FlowerId, f.UserId })
                .IsUnique(true);
        }
    }
}
