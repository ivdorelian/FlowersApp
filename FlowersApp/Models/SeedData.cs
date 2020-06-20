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
                // Look for any flowers.
                if (context.Flowers.Count() >= 2000)
                {
                    return;   // DB table has been seeded
                }

                for (int i = 1; i <= 2000; ++i)
                {
                    context.Flowers.Add(
                        new Flower
                        {
                            Name = $"Flower-{i}",
                            Description = $"Description-{i}",
                            DateAdded = DateTime.Now,
                            MarketPrice = i,
                            FlowerUpkeepDifficulty = FlowerUpkeepDifficulty.Medium
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
