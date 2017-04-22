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
    [Route("api/flights/")]
    public class FlightController : Controller
    {
        private readonly TrackerContext db;
        public FlightController(TrackerContext context) 
        {
            db = context;
        }
        // GET        
        [HttpGet("{carrier}/{flight_number}/{year}/{month}/{day}/{departure_airport}")]
        public async Task<IActionResult> FlightByDeparture(string carrier, int flight_number, int year, int month, int day, string departure_airport)
        {
            using (var client = new HttpClient())
            {
                DateTime date = new DateTime(year, month, day);
                List<Flight> matchedFlights = db.Flights.AsEnumerable()
                        .Where(a => a.Carrier.Equals(carrier) && a.ScheduledDepartureDate.Date == date.Date && a.DepartureAirport.Equals(departure_airport.ToUpper())).ToList();
                
                if (!matchedFlights.Any() || matchedFlights.All(updated => updated.LastUpdated.CompareTo(DateTime.Now.AddSeconds(-30)) <= 0))
                {
                    try
                    {
                        client.BaseAddress = new Uri("https://api.flightstats.com");
                        var response = await client.GetAsync($"/flex/flightstatus/rest/v2/json/flight/status/{carrier}/{flight_number}/dep/{year}/{month}/{day}?appId=0278b7e1&appKey=e50dd1a26feba606205fd19b8c0b187a&utc=false");
                        response.EnsureSuccessStatusCode();
        
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var rawStatus = JsonConvert.DeserializeObject<FlightStatusResponse>(stringResult);
                        IEnumerable<Flight> flights = parseResponseIntoFlight(rawStatus);
                        
                        // add flights to db
                        foreach (Flight f in flights)
                        {
                            var dbFlight = db.Flights.Find(f.FlightId);
                            if (dbFlight == null)
                            {
                                db.Flights.Add(f);
                            }
                            else
                            {
                                dbFlight = f;
                            }
                            db.SaveChanges();

                            // if matching departure airport, add to matchedFlights
                            if (f.DepartureAirport.AirportId.Equals(departure_airport.ToUpper()))
                            {
                                matchedFlights.Add(f);
                            }
                        }
                    }
                    catch (HttpRequestException httpRequestException)
                    {
                        return BadRequest($"Error getting flight status from FlightStats: {httpRequestException.Message}");
                    }
                }

                if (!matchedFlights.Any())
                {
                    return BadRequest($"No matching flights found.");
                }
                else if (matchedFlights.Count() != 1)
                {
                    return BadRequest($"Multiple flights matching that departure airport.");
                }

                return Ok(matchedFlights.First());
            }
        }


        [HttpGet("{carrier}/{flight_number}/{year}/{month}/{day}")]
        public async Task<IActionResult> AllFlights(string carrier, int flight_number, int year, int month, int day)
        {
            using (var client = new HttpClient())
            {
                DateTime date = new DateTime(year, month, day);
                IEnumerable<Flight> matchedFlights = db.Flights.AsEnumerable()
                        .Where(a => a.Carrier.Equals(carrier) && a.ScheduledDepartureDate.Date == date.Date).AsEnumerable();
                
                if (!matchedFlights.Any() || matchedFlights.All(updated => updated.LastUpdated.CompareTo(DateTime.Now.AddSeconds(-30)) <= 0))
                {
                    matchedFlights = new List<Flight>();
                    try
                    {
                        client.BaseAddress = new Uri("https://api.flightstats.com");
                        var response = await client.GetAsync($"/flex/flightstatus/rest/v2/json/flight/status/{carrier}/{flight_number}/dep/{year}/{month}/{day}?appId=0278b7e1&appKey=e50dd1a26feba606205fd19b8c0b187a&utc=false");
                        response.EnsureSuccessStatusCode();
        
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var rawStatus = JsonConvert.DeserializeObject<FlightStatusResponse>(stringResult);
                        matchedFlights = parseResponseIntoFlight(rawStatus);
                        
                        foreach (Flight f in matchedFlights)
                        {
                            var dbFlight = db.Flights.Find(f.FlightId);
                            if (dbFlight == null)
                            {
                                db.Flights.Add(f);
                            }
                            else
                            {
                                dbFlight = f;
                            }
                            db.SaveChanges();
                        }
                    }
                    catch (HttpRequestException httpRequestException)
                    {
                        return BadRequest($"Error getting flight status from FlightStats: {httpRequestException.Message}");
                    }
                }

                if (!matchedFlights.Any())
                {
                    return BadRequest($"No matching flights found.");
                }

                return Ok(matchedFlights);
            }
        }

        private IEnumerable<Flight> parseResponseIntoFlight(FlightStatusResponse response)
        {
            if (response == null || response.appendix == null || response.appendix.airports == null)
            {
                return new List<Flight>();
            }
            // update airports
            foreach (FSAirport airport in response.appendix.airports)
            {
                var dbAirport = db.Airports.Find(airport.fs);
                if (dbAirport == null)
                {
                    Airport a = new Airport(airport.fs);
                    a.IATACode = airport.iata;
                    a.Name = airport.name;
                    a.Address = airport.street1;
                    a.City = airport.city;
                    a.State = airport.stateCode;
                    a.PostalCode = airport.postalCode;
                    a.Country = airport.countryName;
                    dbAirport = a;
                    db.Airports.Add(dbAirport);
                }
            }
            db.SaveChanges();

            // parse flights
            List<Flight> flights = new List<Flight>();
            foreach (FSFlightStatus status in response.flightStatuses)
            {
                Flight f = new Flight();
                f.LastUpdated = DateTime.Now;
                f.FlightId = status.flightId;
                f.Carrier = status.carrierFsCode;
                f.FlightNumber = status.flightNumber;
                f.ScheduledDepartureDate = status.operationalTimes.scheduledGateDeparture.dateLocal;
                f.EstimatedDepartureDate = status.operationalTimes.estimatedGateDeparture.dateLocal;
                f.DepartureAirport = db.Airports.Find(status.departureAirportFsCode);
                f.ScheduledArrivalDate = status.operationalTimes.scheduledGateArrival.dateLocal;
                f.EstimatedArrivalDate = status.operationalTimes.estimatedGateArrival.dateLocal;
                f.ArrivalAirport = db.Airports.Find(status.arrivalAirportFsCode);
                f.Status = status.status;
                f.DepartureGate = status.airportResources.departureGate;
                f.ArrivalGate = status.airportResources.arrivalGate;
                f.DepartureTerminal = status.airportResources.departureTerminal;
                f.ArrivalTerminal = status.airportResources.arrivalTerminal;
                f.BaggageClaim = status.airportResources.baggage;

                flights.Add(f);
            }

            return flights;
        }
    }
}
