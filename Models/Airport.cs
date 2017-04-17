using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlightTracker.Models
{
    public class Airport
    {
        public Airport()
        {
            Food = new HashSet<Item>();
            Lounges = new HashSet<Item>();
            RentalCars = new HashSet<Item>();
            Attractions = new HashSet<Item>();
        }
        public Airport(string airportId)
        {
            AirportId = airportId;
            Food = new HashSet<Item>();
            Lounges = new HashSet<Item>();
            RentalCars = new HashSet<Item>();
            Attractions = new HashSet<Item>();
        }
        public string AirportId { get; set; }
        public string IATACode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public ICollection<Item> Food { get; set; }
        public ICollection<Item> Lounges { get; set; }
        public ICollection<Item> RentalCars { get; set; }
        public ICollection<Item> Attractions { get; set; }
        public ICollection<Item> Drinks { get; set; }
    }
}