using System;

namespace FlightTracker.Models
{
    public class Airport
    {
        public string IATACode { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}