using System;

namespace FlightTracker.Models
{
    public class Flights
    {
        public string Carrier { get; set; }
        public string FlightNumber { get; set; }
        public DateTime Date { get; set; }
        public string ArrivalAirport { get; set; }
    }
}