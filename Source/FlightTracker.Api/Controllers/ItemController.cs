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
    [Route("api/items/")]
    public class ItemController : Controller
    {
        private readonly TrackerContext db;
        public ItemController(TrackerContext context) 
        {
            db = context;
        }
        // GET
        [HttpGet("{airportId}/")]
        public IActionResult AllItemsAtAirport(string airportId)
        {
            List<Item> items = db.Items.Where(i => i.AirportID.Equals(airportId.ToUpper())).ToList();
            if (!items.Any())
            {
                return BadRequest($"No matching items found.");
            }
            else
            {
                return Ok(items);
            }
        }
        // GET
        [HttpGet("item/{itemid}/")]
        public IActionResult SingleItem(string itemid)
        {
            List<Item> items = db.Items.Where(i => i.ItemId.Equals(itemid)).ToList();
            if (!items.Any())
            {
                return BadRequest($"No matching items found.");
            }
            else if (items.Count != 1)
            {
                return BadRequest($"Item ID is not unique.");
            }
            else
            {
                return Ok(items.Single());
            }
        }
        // GET
        [HttpGet("food/")]
        public IActionResult AllFoodItems()
        {
            List<Item> items = db.Items.Where(i => i.Type.Equals("food")).ToList();
            if (!items.Any())
            {
                return BadRequest($"No matching food items found.");
            }
            else
            {
                return Ok(items);
            }
        }
        // GET
        [HttpGet("lounges/")]
        public IActionResult AllLoungeItems()
        {
            List<Item> items = db.Items.Where(i => i.Type.Equals("lounges")).ToList();
            if (!items.Any())
            {
                return BadRequest($"No matching lounge items found.");
            }
            else
            {
                return Ok(items);
            }
        }
        // GET
        [HttpGet("rentalcars/")]
        public IActionResult AllRentalCarItems()
        {
            List<Item> items = db.Items.Where(i => i.Type.Equals("rental cars")).ToList();
            if (!items.Any())
            {
                return BadRequest($"No matching rental car items found.");
            }
            else
            {
                return Ok(items);
            }
        }
        // GET
        [HttpGet("attractions/")]
        public IActionResult AllAttractionItems()
        {
            List<Item> items = db.Items.Where(i => i.Type.Equals("attractions")).ToList();
            if (!items.Any())
            {
                return BadRequest($"No matching attraction items found.");
            }
            else
            {
                return Ok(items);
            }
        }
    }
}
