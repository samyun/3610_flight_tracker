using Microsoft.EntityFrameworkCore;
using FlightTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FlightTracker.Data{
    public class TrackerContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Item> Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "User ID=flight-tracker;Password=pgsql1;Host=localhost;Port=5432;Database=flight-tracker-db;Pooling=true;";
            optionsBuilder.UseNpgsql(connection);
        }
    }
}