using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using CinemaAPI.Data;
using CinemaAPI.DTOs;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatReservationsController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public SeatReservationsController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SeatReservationDTO>>> onGetAsync()
        {
            var seatReservations = await appDbContext.SeatReservations.ToListAsync();

            if (seatReservations == null)
            {
                return NoContent();
            }

            var seatReservationsDTOs = seatReservations
                .Select(seatReservation => new SeatReservationDTO
                {
                    SeatReservationId = seatReservation.SeatReservationId,
                    HallId = seatReservation.HallId,
                    RowNumber = seatReservation.RowNumber,
                    SeatNumber = seatReservation.SeatNumber,
                    IsReserved = seatReservation.IsReserved
                })
                .ToList();

            return Ok(seatReservationsDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeatReservationDTO>> onGetAsync(int id)
        {
            var seatReservation = await appDbContext.SeatReservations.FindAsync(id);

            if (seatReservation == null)
            {
                return NotFound();
            }

            var seatReservationDTO = new SeatReservationDTO
            {
                SeatReservationId = seatReservation.SeatReservationId,
                HallId = seatReservation.HallId,
                RowNumber = seatReservation.RowNumber,
                SeatNumber = seatReservation.SeatNumber,
                IsReserved = seatReservation.IsReserved
            };

            return Ok(seatReservationDTO);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<SeatReservationPostDTO>> onPostAsync(
            [FromBody] SeatReservationPostDTO seatReservationPostDTO
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the hall exists
            var hall = await appDbContext.Halls.FindAsync(seatReservationPostDTO.HallId);
            if (hall == null)
            {
                return NotFound("The specified hall does not exist.");
            }

            // Validate RowNumber and SeatNumber
            if (
                seatReservationPostDTO.RowNumber < 1
                || seatReservationPostDTO.RowNumber > hall.NumberOfRows
                || seatReservationPostDTO.SeatNumber < 1
                || seatReservationPostDTO.SeatNumber > hall.NumberOfSeats
            )
            {
                return BadRequest("The specified RowNumber or SeatNumber is out of range.");
            }

            // Check for existing seat reservation
            var existingReservation = await appDbContext.SeatReservations.FirstOrDefaultAsync(sr =>
                sr.HallId == seatReservationPostDTO.HallId
                && sr.RowNumber == seatReservationPostDTO.RowNumber
                && sr.SeatNumber == seatReservationPostDTO.SeatNumber
            );

            if (existingReservation != null)
            {
                return Conflict(
                    "A seat reservation already exists for the specified RowNumber and SeatNumber in the hall."
                );
            }

            var seatReservation = new SeatReservation
            {
                HallId = seatReservationPostDTO.HallId,
                RowNumber = seatReservationPostDTO.RowNumber,
                SeatNumber = seatReservationPostDTO.SeatNumber,
                IsReserved = false
            };

            appDbContext.SeatReservations.Add(seatReservation);
            await appDbContext.SaveChangesAsync();

            var createdSeatReservation = await appDbContext.SeatReservations.FindAsync(
                seatReservation.SeatReservationId
            );

            if (createdSeatReservation != null)
            {
                //return CreatedAtAction(
                //    nameof(onPostAsync),
                //    new { id = createdGenre.GenreId },
                //    createdGenre
                //);
                return StatusCode(201, createdSeatReservation);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<SeatReservation>> OnPatchAsync(
            int id,
            [FromBody] SeatReservationPatchDTO seatReservationPatchDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingSeatReservation = await appDbContext.SeatReservations.FindAsync(id);
                if (existingSeatReservation == null)
                {
                    return NotFound();
                }

                existingSeatReservation.IsReserved = seatReservationPatchDTO.IsReserved;

                await appDbContext.SaveChangesAsync();
                return Ok(existingSeatReservation);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(
                    "The SeatReservation has been modified or deleted by another process."
                );
            }
        }
    }
}
