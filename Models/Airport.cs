using System;
using System.Collections.Generic;

namespace FlightTracker.Models
{
    public class Airport
    {
        public string IATACode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public List<Category> Categories { get; set; }
    }
}