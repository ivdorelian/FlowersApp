using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowersApp.Models
{
    public class FlowerUserPlants
    {
        public long Id { get; set; }
        // eventual un date time
        public int NumberOfPlants { get; set; }
        
        public long FlowerId { get; set; }
        public Flower Flower { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
