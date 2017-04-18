using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FlightTracker.Models
{
    public class Airport
    {
        public Airport()
        {
            Items = new HashSet<Item>();
        }
        public Airport(string airportId)
        {
            AirportId = airportId;
            Items = new HashSet<Item>();
        }
        public string AirportId { get; set; }
        public string IATACode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public ICollection<Item> Items { get; set; }

        public ICollection<Item> Food()
        {
            return Items.Where(a => a.Type.Equals("food")).ToList();
        }

        public ICollection<Item> RentalCars()
        {
            return Items.Where(a => a.Type.Equals("rental car")).ToList();
        }

        public ICollection<Item> Lounges()
        {
            return Items.Where(a => a.Type.Equals("lounge")).ToList();
        }

        public ICollection<Item> Attractions()
        {
            return Items.Where(a => a.Type.Equals("attraction")).ToList();
        }
    }
}