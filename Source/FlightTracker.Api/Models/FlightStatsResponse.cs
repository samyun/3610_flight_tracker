using System;
using System.Collections.Generic;

namespace FlightTracker.Models
{
    public class FlightStatusResponse
    {
        public FSAppendix appendix { get; set; }
        public IEnumerable<FSFlightStatus> flightStatuses { get; set; }
    }

    public class FSFlightStatus
    {
        public int flightId { get; set; }
        public string carrierFsCode { get; set; }
        public string flightNumber { get; set; }
        public string departureAirportFsCode { get; set; }
        public string arrivalAirportFsCode { get; set; }
        public string status { get; set; }
        public FSOperationalTimes operationalTimes { get; set; }
        public FSDelays delays { get; set; }
        public FSAirportResources airportResources { get; set; }
        public IEnumerable<FSDelta> flightStatusUpdates { get; set; }
    }

    public class FSDelta
    {
        public DateTime updatedAt { get; set; }
        public string source { get; set; }
        public IEnumerable<FSTextField> updatedTextFields { get; set; }
        public IEnumerable<FSDateField> updatedDateFields { get; set; }
    }

    public class FSDateField
    {
        public string field { get; set; }
        public DateTime newDateLocal { get; set; }
        public DateTime newDateUtc { get; set; }
        public DateTime originalDateLocal { get; set; }
        public DateTime originalDateUtc { get; set; }
    }

    public class FSTextField
    {
        public string field { get; set; }
        public string newText { get; set; }
        public string originalText { get; set; }
        public string updatedText { get; set; }
    }

    public class FSDelays
    {
        public int departureGateDelayMinutes { get; set; }
        public int arrivalGateDelayMinutes { get; set; }
    }

    public class FSOperationalTimes
    {
        public FSDate publishedDeparture { get; set; }
        public FSDate publishedArrival { get; set; }
        public FSDate scheduledGateDeparture { get; set; }
        public FSDate estimatedGateDeparture { get; set; }
        public FSDate actualGateDeparture { get; set; }
        public FSDate scheduledGateArrival { get; set; }
        public FSDate estimatedGateArrival { get; set; }
        public FSDate actualGateArrival{ get; set; }
    }

    public class FSDate
    {
        public DateTime dateLocal { get; set; }
        public DateTime dateUtc { get; set; }

    }

    public class FSAirportResources
    {
        public string departureGate { get; set; }
        public string departureTerminal { get; set; }
        public string arrivalGate { get; set; }
        public string arrivalTerminal { get; set; }
        public string baggage { get; set; }
    }

    public class FSAppendix
    {
        public IEnumerable<FSAirport> airports;
    }

    public class FSAirport
    {
        public string fs { get; set; }
        public string iata { get; set; }
        public string name { get; set; }
        public string street1 { get; set; }
        public string city { get; set; }
        public string stateCode { get; set; }
        public string postalCode { get; set; }
        public string countryName { get; set; }
    }
}