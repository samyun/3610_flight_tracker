using System;
using Xunit;
using FlightTracker.Models;
using FlightTracker.Controllers;
using FlightTracker.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FlightTracker.Api.Tests
{
    public class ItemTest
    {
        private TrackerContext db;

        public ItemTest()
        {

            db = new TrackerContext();
        }

        [Fact]
        public void TestAddingItemToDb()
        {
            //Arrange
            Item item = new Item
            {
                AirportID = "CMH",
                Type = "food",
                Name = "Unit Test Item",
                Phone = "999-999-9999",
                Address = "12345 Test Ave, Columbus, OH, 43219",
                Description = "Unit Test for Food"
            };
            string itemID = item.ItemId;

            Airport cmh = db.Airports.Find("CMH");
            Assert.NotNull(cmh);

            //Act
            cmh.Items.Add(item);
            db.SaveChanges();

            //Assert
            // Check item is in Items table
            List<Item> singleItemList = db.Items.Where(i => i.ItemId.Equals(itemID)).ToList();
            Assert.Single(singleItemList);

            // Check contents of item from DB is as expected
            Assert.Equal(singleItemList[0].Address, "12345 Test Ave, Columbus, OH, 43219");
            Assert.Equal(singleItemList[0].AirportID, "CMH");
            Assert.Equal(singleItemList[0].Name, "Unit Test Item");
            Assert.Equal(singleItemList[0].Phone, "999-999-9999");
            Assert.Equal(singleItemList[0].Description, "Unit Test for Food");
            
            //Destroy
            db.Items.Remove(item);
            db.SaveChanges();

        }
    }
}
