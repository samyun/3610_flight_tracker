using System;
using Xunit;
using FlightTracker.Models;
using FlightTracker.Controllers;

namespace FlightTracker.Api.Tests
{
    public class ItemTest
    {
        [Fact]
        public void Test()
        {
            //Arrange
            var item = new Item
            {
                AirportID = "CMH",
                Type = "Food",
                Name = "John Glenn Columbus International Airport",
                Phone = "123-345-1245",
                Address = "4600 International Gateway, Columbus, OH, 43219",
                Description = "Test for Food"
            };

                var item2 = new Item
            {
                AirportID = "CMH",
                Type = "Food",
                Name = "John Glenn Columbus International Airport",
                Phone = "123-345-1245",
                Address = "4600 International Gateway, Columbus, OH, 43219",
                Description = "Test for Food"
            };

            //Assert
            Assert.NotNull(item);
            Assert.NotNull(item2);
            Assert.Equal(item, item2);
            Assert.NotEqual(item, item2);

        }
    }
}
