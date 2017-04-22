using System;
using Xunit;
using FlightTracker.Api.Controllers;
using FlightTracker.Api.Models;
using FlightTracker.Api.Data;

namespace FlightTracker.Api.Tests
{
    public class ItemTest
    {
        [Fact]
        public void Test()
        {
          var item = new Item 
          (
              //Arrange
              airportId = "CMH",
              type = "Food",
              name = "John Glenn International Airport",
              phone = "123-456-3765",
              address = "4600 International Gateway, Columbus, OH 43219",
              description = "Test food for CMH"
          );
          
          //Act
            var Result = AllItemsAtAirport.get(item);

          //Assert

        
        }
    }
}