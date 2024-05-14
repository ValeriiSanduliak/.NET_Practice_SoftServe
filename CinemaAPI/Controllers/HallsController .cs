using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using CinemaAPI.Data;
using CinemaAPI.DTOs;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public HallsController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hall>>> onGetAsync()
        {
            var halls = await appDbContext.Halls.ToListAsync();
            return Ok(halls);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hall>> onGetHallAsync(int id)
        {
            var hall = await appDbContext.Halls.FindAsync(id);
            if (hall == null)
            {
                return NotFound();
            }
            return Ok(hall);
        }

        [HttpPost]
        public async Task<ActionResult<Hall>> onPostAsync([FromBody] HallDTO hallDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hall = new Hall
            {
                HallName = hallDTO.HallName,
                HallType = hallDTO.HallType,
                NumberOfRows = hallDTO.NumberOfRows,
                NumberOfSeats = hallDTO.NumberOfSeats
            };

            appDbContext.Halls.Add(hall);
            await appDbContext.SaveChangesAsync();

            var createdHall = await appDbContext.Halls.FindAsync(hall.HallId);

            if (createdHall != null)
            {
                return StatusCode(201, createdHall);
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<Hall>> onPostAsync([FromBody] Hall hall)
        //{
        //    if (hall == null || hall.SeatReservationIds == null)
        //    {
        //        return BadRequest("Invalid request body.");
        //    }

        //    // Retrieve SeatReservations based on the provided IDs
        //    var seatReservations = await appDbContext
        //        .SeatReservations.Where(sr =>
        //            hall.SeatReservationIds.Contains(sr.SeatReservationId)
        //        )
        //        .ToListAsync();

        //    appDbContext.Halls.Add(hall);
        //    await appDbContext.SaveChangesAsync();

        //    return CreatedAtAction(nameof(onGetAsync), new { id = hall.HallId }, hall);
        //}

        [HttpPatch("{id}")]
        public async Task<ActionResult<Hall>> OnPatchAsync(int id, [FromBody] Hall hall)
        {
            try
            {
                var existingHall = await appDbContext.Halls.FindAsync(id);
                if (existingHall == null)
                {
                    return NotFound();
                }

                // Update the existing hall entity with the values from the incoming entity
                if (hall.HallName != null)
                {
                    existingHall.HallName = hall.HallName;
                }

                await appDbContext.SaveChangesAsync();
                return Ok(existingHall);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency conflict
                return Conflict("The hall has been modified or deleted by another process.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Hall>> onDeleteAsync(int id)
        {
            var hall = await appDbContext.Halls.FindAsync(id);
            if (hall == null)
            {
                return NotFound();
            }
            appDbContext.Halls.Remove(hall);
            await appDbContext.SaveChangesAsync();
            return Ok(hall);
        }
    }
}
