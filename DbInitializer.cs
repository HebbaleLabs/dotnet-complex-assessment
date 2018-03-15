using System;
using System.Linq;
using Assessment.Models;

namespace Assessment
{
    public static class DbInitializer
    {
        public static void Initialize(ParkingSpotContext context)
        {
            context.Database.EnsureCreated();

            if (context.ParkingSpots.Count() == 0)
            {
                context.ParkingSpots.Add(new ParkingSpot { Lat = 10, Long = 10, capacity = 200, usage = 0 });
                context.ParkingSpots.Add(new ParkingSpot { Lat = 5, Long = 20, capacity = 100, usage = 0 });
                context.SaveChanges();
            }
        }
    }
}
