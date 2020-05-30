using FlowersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowersApp.ViewModels
{
    public class FlowerDetails
    {
        public long Id { get; set; }
        //[MaxLength(10, ErrorMessage = "Name must have at most 10 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public long MarketPrice { get; set; }
        public FlowerUpkeepDifficulty FlowerUpkeepDifficulty { get; set; }

        public List<CommentForFlowerDetails> Comments { get; set; }

        public static FlowerDetails FromFlower(Flower flower)
        {
            return new FlowerDetails
            {
                Id = flower.Id,
                Name = flower.Name,
                Description = flower.Description,
                DateAdded = flower.DateAdded,
                FlowerUpkeepDifficulty = flower.FlowerUpkeepDifficulty,
                MarketPrice = flower.MarketPrice,
                Comments = flower.Comments.Select(c => CommentForFlowerDetails.FromComment(c)).ToList()
            };
        }
    }
}
