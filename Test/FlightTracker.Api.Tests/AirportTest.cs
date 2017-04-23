using System;
using Xunit;
using FlightTracker.Models;
using FlightTracker.Controllers;

namespace FlightTracker.Api.Tests
{
    public class AirportTest
    {
        [Fact]
        public void Test()
        {
            //Arrange
            var airport1 = new Airport("CMH");
            var airport2 = new Airport("CMH");

            //Assert
            Assert.NotNull(airport1);
            Assert.NotNull(airport2);
            Assert.Equal(airport1, airport2);
            Assert.NotEqual(airport1, airport2);

        }
    }
}
