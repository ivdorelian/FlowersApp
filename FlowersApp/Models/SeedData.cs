using FlowersApp.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowersApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FlowersDbContext(serviceProvider.GetRequiredService<DbContextOptions<FlowersDbContext>>()))
            {
                if (!context.Users.Any())
                {
                    context.Users.Add(new User
                    {
                        FirstName = "First",
                        LastName = "Last",
                        Username = "FirstUsername",
                        Password = HashUtils.GetHashString("parolasigura")
                    });
                    context.SaveChanges();
                }

                // Look for any flowers.
                if (context.Flowers.Any())
                {
                    return;   // DB table has been seeded
                }

                context.Flowers.AddRange(
                    new Flower
                    {
                        Name = "Rose",
                        Description = "Has thorns",
                        DateAdded = DateTime.Now,
                        MarketPrice = 10,
                        FlowerUpkeepDifficulty = FlowerUpkeepDifficulty.Medium
                    },
                    
                    new Flower
                    {
                        Name = "Tulip",
                        Description = "Does not have thorns",
                        DateAdded = DateTime.UtcNow,
                        MarketPrice = 15,
                        FlowerUpkeepDifficulty = FlowerUpkeepDifficulty.Easy
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
