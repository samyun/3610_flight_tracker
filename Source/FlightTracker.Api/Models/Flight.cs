using System;

namespace FlightTracker.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Carrier { get; set; }
        public string FlightNumber { get; set; }
        public DateTime ScheduledDepartureDate { get; set; }
        public DateTime EstimatedDepartureDate { get; set; }
        public Airport DepartureAirport { get; set; }
        public DateTime ScheduledArrivalDate { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }
        public Airport ArrivalAirport { get; set; }
        public string Status { get; set; }
        public string DepartureGate { get; set; }
        public string ArrivalGate { get; set; }
        public string DepartureTerminal { get; set; }
        public string ArrivalTerminal { get; set; }
        public string BaggageClaim { get; set; }

    }
}