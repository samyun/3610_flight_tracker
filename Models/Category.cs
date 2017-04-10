using System.Collections.Generic;

namespace FlightTracker.Models
{
    public class Category
    {
        public string Airport { get; set; }
        public string Type { get; set; }
        public List<Item> Items { get; set; }
    }
}