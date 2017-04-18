using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightTracker.Models;
using FlightTracker.Data;
using System.Net.Http;
using Newtonsoft.Json;


namespace FlightTracker.Controllers
{
    [Route("api/airports/")]
    public class AirportController : Controller
    {
        private readonly TrackerContext db;
        public AirportController(TrackerContext context) 
        {
            db = context;
        }
        // GET
        [HttpGet("")]
        public IActionResult AllAirports(string airportId)
        {
            List<Airport> airports = db.Airports.ToList();
            if (!airports.Any())
            {
                return BadRequest($"No matching airport found.");
            }
            else
            {
                List<Item> allItems = db.Items.ToList();
                if (allItems.Any())
                {
                    foreach (Airport a in airports)
                    {
                        a.Items = allItems.Where(i => i.AirportID.Equals(a.AirportId)).ToList();
                    }
                }
                return Ok(airports);
            }
        }
        [HttpGet("{airportId}")]
        public IActionResult Airport(string airportId)
        {
            Airport airport = db.Airports.Find(airportId.ToUpper());
            if (airport == null)
            {
                return BadRequest($"No matching airport found.");
            }
            else
            {
                List<Item> allItems = db.Items.ToList();
                if (allItems.Any())
                {
                    airport.Items = allItems.Where(i => i.AirportID.Equals(airport.AirportId)).ToList();
                }
                return Ok(airport);
            }
        }
        // GET
        [HttpGet("{airportId}/food")]
        public IActionResult Food(string airportId)
        {
            Airport airport = db.Airports.Find(airportId.ToUpper());
            if (airport == null)
            {
                return BadRequest($"No matching airport found.");
            }
            else
            {
                List<Item> allItems = db.Items.ToList();
                if (allItems.Any())
                {
                    airport.Items = allItems.Where(i => i.AirportID.Equals(airport.AirportId)).Where(i => i.Type.Equals("food")).ToList();
                }
                return Ok(airport);
            }
        }
        // GET
        [HttpGet("{airportId}/rentalcars")]
        public IActionResult RentalCars(string airportId)
        {
            Airport airport = db.Airports.Find(airportId.ToUpper());
            if (airport == null)
            {
                return BadRequest($"No matching airport found.");
            }
            else
            {
                List<Item> allItems = db.Items.ToList();
                if (allItems.Any())
                {
                    airport.Items = allItems.Where(i => i.AirportID.Equals(airport.AirportId)).Where(i => i.Type.Equals("rental car")).ToList();
                }
                return Ok(airport);
            }
        }
        // GET
        [HttpGet("{airportId}/attractions")]
        public IActionResult Attractions(string airportId)
        {
            Airport airport = db.Airports.Find(airportId.ToUpper());
            if (airport == null)
            {
                return BadRequest($"No matching airport found.");
            }
            else
            {
                List<Item> allItems = db.Items.ToList();
                if (allItems.Any())
                {
                    airport.Items = allItems.Where(i => i.AirportID.Equals(airport.AirportId)).Where(i => i.Type.Equals("attraction")).ToList();
                }
                return Ok(airport);
            }
        }
        // GET
        [HttpGet("{airportId}/lounges")]
        public IActionResult Lounges(string airportId)
        {
            Airport airport = db.Airports.Find(airportId.ToUpper());
            if (airport == null)
            {
                return BadRequest($"No matching airport found.");
            }
            else
            {
                List<Item> allItems = db.Items.ToList();
                if (allItems.Any())
                {
                    airport.Items = allItems.Where(i => i.AirportID.Equals(airport.AirportId)).Where(i => i.Type.Equals("lounge")).ToList();
                }
                return Ok(airport);
            }
        }
    }
}
