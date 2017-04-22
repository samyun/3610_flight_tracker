using System;
using Xunit;
using FlightTracker.Models;

namespace FlightTracker.Api.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var item = new Item
            {
                AirportID = "CMH1001",
                Type = "food",
                Name = "CMH Cake",
                Phone = "614-123-456",
                Address = "32 Main Street, Columbus OH 43201",
                Description = "Columbus Home-Made Cake"
            };
        }
    }
}
