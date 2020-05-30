using System;
using System.Collections.Generic;

namespace FlowersApp.Models
{
    public enum FlowerUpkeepDifficulty
    {
        Easy,
        Medium,
        Hard
    }

    public class Flower
    {
        public long Id { get; set; }
        //[MaxLength(10, ErrorMessage = "Name must have at most 10 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public long MarketPrice { get; set; }
        public FlowerUpkeepDifficulty FlowerUpkeepDifficulty { get; set; }

        public User AddedBy { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
