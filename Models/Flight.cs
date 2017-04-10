using System;

namespace FlightTracker.Models
{
    public class Flight
    {
        public string Carrier { get; set; }
        public string FlightNumber { get; set; }
        public DateTime Date { get; set; }
        public string DepartureAirport { get; set; }
    }
}