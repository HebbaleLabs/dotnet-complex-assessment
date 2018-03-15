using System;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Models
{
    public class ParkingSpotContext : DbContext
    {
        public ParkingSpotContext(DbContextOptions<ParkingSpotContext> options) : base(options)
        {
        }

        public DbSet<ParkingSpot> ParkingSpots { get; set; }
    }
}
