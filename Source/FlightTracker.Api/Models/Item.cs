using System;
using System.ComponentModel.DataAnnotations;

namespace FlightTracker.Models
{
    public class Item
    {
        public Item() {
            ItemId = Guid.NewGuid().ToString();
        }
        public Item(string airportID, string type, string name, string address, string description)
        {
            ItemId = Guid.NewGuid().ToString();
            AirportID = airportID;
            Type = type;
            Name = name;
            Address = address;
            Description = description;
        }
        public string ItemId { get; set; }
        public string AirportID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}