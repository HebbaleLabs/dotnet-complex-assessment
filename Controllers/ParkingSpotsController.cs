using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assessment.Controllers
{
    [Route("api/[controller]")]
    public class ParkingSpotsController : Controller
    {

        private readonly ParkingSpotContext _context;

        public ParkingSpotsController(ParkingSpotContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ParkingSpot> GetAll()
        {
            return _context.ParkingSpots.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetParkingSpot")]
        public IActionResult GetById(long id)
        {
            var item = _context.ParkingSpots.FirstOrDefault(t => t.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ParkingSpot item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            _context.ParkingSpots.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetParkingSpot", new { id = item.Id }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]ParkingSpot item)
        {
            if(item == null || item.Id != id)
            {
                return BadRequest();
            }

            var parkingSpot = _context.ParkingSpots.FirstOrDefault(t => t.Id == id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            parkingSpot.Lat = item.Lat;
            parkingSpot.Long = item.Long;
            parkingSpot.capacity = item.capacity;
            parkingSpot.usage = item.usage;

            _context.Update(parkingSpot);
            _context.SaveChanges();

            return Ok(item);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item = _context.ParkingSpots.Find(id);

            if(item == null)
            {
                return NotFound();
            }

            _context.ParkingSpots.Remove(item);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
