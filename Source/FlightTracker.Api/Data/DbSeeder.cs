using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightTracker.Models;

namespace FlightTracker.Data
{
    public class DbSeeder
    {

        private TrackerContext db;
        private RoleManager<IdentityRole> RoleManager;
        private UserManager<ApplicationUser> UserManager;

        public DbSeeder(TrackerContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            db = dbContext;
            RoleManager = roleManager;
            UserManager = userManager;
        }

        public async Task SeedAsync()
        {
            // Create the Db if it doesn’t exist
            db.Database.EnsureCreated();

            // Create default Users
            await CreateUsersAsync();

            // Create Test Airports
            await PopulateAirportsAsync();

        }

        private async Task CreateUsersAsync()
        {
            // local variables
            DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
            DateTime lastModifiedDate = DateTime.Now;
            string role_Administrators = "Administrators";
            string role_Registered = "Registered";

            //Create Roles (if they doesn't exist yet)
            if (!await RoleManager.RoleExistsAsync(role_Administrators))
            {
                await RoleManager.CreateAsync(new IdentityRole(role_Administrators));
            }
            if (!await RoleManager.RoleExistsAsync(role_Registered))
            {
                await RoleManager.CreateAsync(new IdentityRole(role_Registered));
            }

            // Create the "Admin" ApplicationUser account (if it doesn't exist already)
            var user_Admin = new ApplicationUser()
            {
                UserName = "Admin",
                Email = "admin@flighttracker.com"
            };

            await CreateUserAsync(user_Admin, role_Administrators);

            // Create some sample registered user accounts (if they don't exist already)
            var user_Jeff = new ApplicationUser()
            {
                UserName = "Jeff",
                Email = "Jeff@fisherinsurance.com"
            };

            await CreateUserAsync(user_Jeff, role_Registered);

            var user_Nancy = new ApplicationUser()
            {
                UserName = "Nancy",
                Email = "Nancy@fisherinsurance.com"
            };

            await CreateUserAsync(user_Nancy, role_Registered);

            user_Admin.EmailConfirmed = true;
            user_Admin.LockoutEnabled = false;

            user_Jeff.EmailConfirmed = true;
            user_Jeff.LockoutEnabled = false;

            user_Nancy.EmailConfirmed = true;
            user_Nancy.LockoutEnabled = false;

            await db.SaveChangesAsync();
        }

        private async Task CreateUserAsync(ApplicationUser user, string role)
        {
            if (await UserManager.FindByEmailAsync(user.Email) == null)
            {
                await UserManager.CreateAsync(user, "P@ssw0rd");
                await UserManager.AddToRoleAsync(user, role);
            }
        }

        private async Task PopulateAirportsAsync()
        {
            Airport cmh = createCMH();
            await CreateAirportAsync(cmh, "CMH");
            Airport clt = createCLT();
            await CreateAirportAsync(clt, "CLT");
            Airport stx = createSTX();
            await CreateAirportAsync(stx, "STX");

        }

        private Airport createCMH()
        {
            Airport airport = new Airport("CMH");
            airport.IATACode = "CMH";
            airport.City = "Columbus";
            airport.Address = "4600 International Gateway";
            airport.Country = "US";
            airport.Name = "John Glenn Columbus International Airport";
            airport.PostalCode = "43219";
            airport.State = "OH";
            airport.Items.Add(new Item("CMH", "food", "Test CMH Food", "123-456-7890", "123 Main St Columbus OH 43201", "Test Food at CMH"));
            airport.Items.Add(new Item("CMH", "attractions", "Test CMH Attraction", "123-456-7890", "234 Main St Columbus OH 43201", "Test Attraction at CMH"));
            airport.Items.Add(new Item("CMH", "lounges", "Test CMH Lounge", "123-456-7890", "345 Main St Columbus OH 43201", "Test Lounge at CMH"));
            airport.Items.Add(new Item("CMH", "rental cars", "Test CMH Rental Car", "123-456-7890", "456 Main St Columbus OH 43201", "Test Rental Car at CMH"));

            return airport;
        }

        private Airport createCLT()
        {
            Airport airport = new Airport("CLT");
            airport.IATACode = "CLT";
            airport.City = "Charlotte";
            airport.Address = "5501 Josh Birmingham Parkway";
            airport.Country = "US";
            airport.Name = "Charlotte Douglas International Airport";
            airport.PostalCode = "28204";
            airport.State = "NC";
            airport.Items.Add(new Item("CLT", "food", "Test CLT Food", "123-456-7890", "123 Main St Charlotte NC 28204", "Test Food at CLT"));
            airport.Items.Add(new Item("CLT", "attractions", "Test CLT Attraction", "123-456-7890", "234 Main St Charlotte NC 28204", "Test Attraction at CLT"));
            airport.Items.Add(new Item("CLT", "lounges", "Test CLT Lounge", "123-456-7890", "345 Main St Charlotte NC 28204", "Test Lounge at CLT"));
            airport.Items.Add(new Item("CLT", "rental cars", "Test CLT Rental Car", "123-456-7890", "456 Main St Charlotte NC 28204", "Test Rental Car at CLT"));

            return airport;
        }

        private Airport createSTX()
        {
            Airport airport = new Airport("STX");
            airport.IATACode = "STX";
            airport.City = "Saint Croix";
            airport.Country = "VI";
            airport.Name = "Henry E. Rohlsen Airport";
            airport.Items.Add(new Item("STX", "food", "Test STX Food", "123-456-7890", "123 Main St Saint Croix", "Test Food at STX"));
            airport.Items.Add(new Item("STX", "attractions", "Test STX Attraction", "123-456-7890", "234 Main St Saint Croix", "Test Attraction at STX"));
            airport.Items.Add(new Item("STX", "lounges", "Test STX Lounge", "123-456-7890", "345 Main St Saint Croix", "Test Lounge at STX"));
            airport.Items.Add(new Item("STX", "rental cars", "Test STX Rental Car", "123-456-7890", "456 Main St Saint Croix", "Test Rental Car at STX"));

            return airport;
        }

        private async Task CreateAirportAsync(Airport airport, string airportId)
        {
            if (await db.Airports.FindAsync(airportId) == null)
            {
                await db.Airports.AddAsync(airport);
                await db.SaveChangesAsync();
            }
        }
    }
}