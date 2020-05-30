using FlowersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowersApp.ViewModels
{
    public class FlowerWithNumberOfComments
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public long MarketPrice { get; set; }
        public FlowerUpkeepDifficulty FlowerUpkeepDifficulty { get; set; }
        public long NumberOfComments { get; set; }

        public static FlowerWithNumberOfComments FromFlower(Flower flower)
        {
            return new FlowerWithNumberOfComments
            {
                Id = flower.Id,
                Name = flower.Name,
                Description = flower.Description,
                DateAdded = flower.DateAdded,
                FlowerUpkeepDifficulty = flower.FlowerUpkeepDifficulty,
                MarketPrice = flower.MarketPrice,
                NumberOfComments = flower.Comments.Count
            };
        }
    }
}
