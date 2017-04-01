using System;
using System.Collections.Generic;

namespace FlightTracker.Models
{
    public class Item
    {
        public string Airport { get; set; }
        public string Type { get; set; }
        public List<String> Items { get; set; }
    }
}