using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using CinemaAPI.Data;
using CinemaAPI.DTOs;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        //[HttpGet]
        //public async Task<ActionResult<List<Hall>>> onGetAsync()
        //{
        //    //var halls = await appDbContext.Halls.ToListAsync();
        //    var halls = await appDbContext.Halls.Include(h => h.MovieSessions).ToListAsync();
        //    return Ok(halls);
        //}
        [HttpGet]
        public async Task<ActionResult<List<HallDTO>>> onGetAsync()
        {
            var halls = await appDbContext
                .Halls.Include(h => h.MovieSessions)
                .ThenInclude(ms => ms.Movie)
                .ToListAsync();

            var hallDTOs = halls
                .Select(h => new HallDTO
                {
                    HallId = h.HallId,
                    HallName = h.HallName,
                    HallType = h.HallType,
                    NumberOfRows = h.NumberOfRows,
                    NumberOfSeats = h.NumberOfSeats,
                    MovieSessions = h
                        .MovieSessions.Select(ms => new MovieSessionDTO
                        {
                            MovieSessionId = ms.MovieSessionId,
                            MovieTitle = ms.Movie.MovieTitle,
                            StartTime = ms.StartTime.Value
                        })
                        .ToList()
                })
                .ToList();

            return Ok(hallDTOs);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Hall>> onGetHallAsync(int id)
        //{

        //var hall = await appDbContext.Halls.FindAsync(id);
        //if (hall == null)
        //{
        //    return NotFound();
        //}
        //return Ok(hall);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<HallDTO>> GetHallByIdAsync(int id)
        {
            var hall = await appDbContext
                .Halls.Include(h => h.MovieSessions)
                .ThenInclude(ms => ms.Movie)
                .FirstOrDefaultAsync(h => h.HallId == id);

            if (hall == null)
            {
                return NotFound();
            }

            var hallDTO = new HallDTO
            {
                HallId = hall.HallId,
                HallName = hall.HallName,
                HallType = hall.HallType,
                NumberOfRows = hall.NumberOfRows,
                NumberOfSeats = hall.NumberOfSeats,
                MovieSessions = hall
                    .MovieSessions.Select(ms => new MovieSessionDTO
                    {
                        MovieSessionId = ms.MovieSessionId,
                        MovieTitle = ms.Movie.MovieTitle,
                        StartTime = ms.StartTime.Value
                    })
                    .ToList()
            };

            return Ok(hallDTO);
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
        public async Task<ActionResult<HallPatchDTO>> OnPatchAsync(
            int id,
            [FromBody] HallPatchDTO hallDTO
        )
        {
            try
            {
                var existingHall = await appDbContext.Halls.FindAsync(id);
                if (existingHall == null)
                {
                    return NotFound();
                }

                // Update the existing hall entity with the values from the incoming DTO
                if (!string.IsNullOrEmpty(hallDTO.HallName))
                {
                    existingHall.HallName = hallDTO.HallName;
                }
                if (!string.IsNullOrEmpty(hallDTO.HallType))
                {
                    existingHall.HallType = hallDTO.HallType;
                }
                if (hallDTO.NumberOfRows.HasValue)
                {
                    existingHall.NumberOfRows = hallDTO.NumberOfRows.Value;
                }
                if (hallDTO.NumberOfSeats.HasValue)
                {
                    existingHall.NumberOfSeats = hallDTO.NumberOfSeats.Value;
                }

                await appDbContext.SaveChangesAsync();

                return Ok(existingHall);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency conflict
                return Conflict("The hall has been modified or deleted by another process.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //{
        //    try
        //    {
        //        var existingHall = await appDbContext.Halls.FindAsync(id);
        //        if (existingHall == null)
        //        {
        //            return NotFound();
        //        }

        //        // Update the existing hall entity with the values from the incoming entity
        //        if (hallDTO.HallName != null)
        //        {
        //            existingHall.HallName = hallDTO.HallName;
        //        }

        //        await appDbContext.SaveChangesAsync();
        //        return Ok(existingHall);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        // Handle concurrency conflict
        //        return Conflict("The hall has been modified or deleted by another process.");
        //    }
        //}


        [HttpDelete("{id}")]
        public async Task<ActionResult<Hall>> onDeleteAsync(int id)
        {
            var hall = await appDbContext
                .Halls.Include(h => h.MovieSessions)
                .Include(h => h.SeatReservations)
                .FirstOrDefaultAsync(h => h.HallId == id);

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
