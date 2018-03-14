using System;
namespace Assessment.Models
{
    public class ParkingSpot
    {
        public long Id { get; set; }
        public long Lat { get; set; }
        public long Long { get; set; }
        public long capacity { get; set; }
        public long usage { get; set; }
    }
}
