using System.IdentityModel.Tokens.Jwt;
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
    public class ReservationController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public ReservationController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet("PlacesAndSessions")]
        public async Task<ActionResult<List<Reservation>>> onGetAsync()
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);

            var reservations = await appDbContext
                .Prices.Include(m => m.Movie)
                .ThenInclude(ms => ms.MovieSessions)
                .Include(s => s.SeatReservation)
                .ThenInclude(h => h.Hall)
                .Where(p => !p.SeatReservation.IsReserved && p.Movie.EndOfShow >= currentDate)
                .GroupBy(p => new
                {
                    p.Movie.MovieSessions.FirstOrDefault().MovieSessionId,
                    p.Movie.MovieTitle
                })
                .Select(group => new
                {
                    MovieSessionId = group.Key.MovieSessionId,
                    MovieTitle = group.Key.MovieTitle,
                    StartTime = group
                        .FirstOrDefault()
                        .Movie.MovieSessions.FirstOrDefault()
                        .StartTime,
                    AvailibleSeats = group
                        .Select(p => p.SeatReservation.RowNumber)
                        .Distinct()
                        .Select(rowNumber => new
                        {
                            RowNumber = rowNumber,
                            SeatNumbers = group
                                .Where(p => p.SeatReservation.RowNumber == rowNumber)
                                .Select(p => p.SeatReservation.SeatNumber)
                                .OrderBy(sn => sn)
                                .ToList()
                        })
                })
                .ToListAsync();

            return Ok(reservations);
        }

        [HttpGet("PlacesAndSessions{id}")]
        public async Task<ActionResult<List<Reservation>>> onGetAsync(int id)
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Now);

            var reservations = await appDbContext
                .Prices.Include(m => m.Movie)
                .ThenInclude(ms => ms.MovieSessions)
                .Include(s => s.SeatReservation)
                .ThenInclude(h => h.Hall)
                .Where(p =>
                    !p.SeatReservation.IsReserved
                    && p.Movie.EndOfShow >= currentDate
                    && p.Movie.MovieSessions.Any(ms => ms.MovieSessionId == id)
                )
                .GroupBy(p => new
                {
                    p.Movie.MovieSessions.FirstOrDefault().MovieSessionId,
                    p.Movie.MovieTitle
                })
                .Select(group => new
                {
                    MovieSessionId = group.Key.MovieSessionId,
                    MovieTitle = group.Key.MovieTitle,
                    StartTime = group
                        .FirstOrDefault()
                        .Movie.MovieSessions.FirstOrDefault()
                        .StartTime,
                    AvailibleSeats = group
                        .Select(p => p.SeatReservation.RowNumber)
                        .Distinct()
                        .Select(rowNumber => new
                        {
                            RowNumber = rowNumber,
                            SeatNumbers = group
                                .Where(p => p.SeatReservation.RowNumber == rowNumber)
                                .Select(p => p.SeatReservation.SeatNumber)
                                .OrderBy(sn => sn)
                                .ToList()
                        })
                })
                .ToListAsync();

            if (reservations.Count == 0)
            {
                return NotFound();
            }

            return Ok(reservations);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<List<Reservation>>> onGetReservationsAsync()
        {
            var reservations = await appDbContext
                .Reservations.Select(item => new
                {
                    ReservationId = item.ReservationId,
                    UserId = item.UserId,
                    MovieSessionId = item.MovieSessionId,
                    PriceId = item.PriceId
                })
                .ToListAsync();

            if (reservations.Count == 0)
            {
                return NotFound();
            }
            return Ok(reservations);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Reservation>>> onGetReservatiByIdonsAsync(int id)
        {
            var reservations = await appDbContext
                .Reservations.Where(r => r.ReservationId == id)
                .Select(item => new
                {
                    ReservationId = item.ReservationId,
                    UserId = item.UserId,
                    MovieSessionId = item.MovieSessionId,
                    PriceId = item.PriceId
                })
                .ToListAsync();

            if (reservations.Count == 0)
            {
                return NotFound();
            }
            return Ok(reservations);
        }

        [Authorize(Roles = "user, admin")]
        [HttpPost]
        public async Task<ActionResult<Reservation>> onPostAsync(
            int movieSessionId,
            int rowNumber,
            int seatNumber
        )
        {
            // Get token from header

            string token = Request.Headers["Authorization"];

            if (token.StartsWith("Bearer"))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }

            var handler = new JwtSecurityTokenHandler();

            JwtSecurityToken jwt = null;
            try
            {
                jwt = handler.ReadJwtToken(token);
            }
            catch (Exception)
            {
                return Unauthorized("Incorrect or damaged token.");
            }

            string email =
                jwt.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value ?? string.Empty;

            // Find the user by email
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserEmail == email);

            if (user == null)
            {
                // User with this email does not exist
                return NotFound("User not found");
            }

            var movieSession = await appDbContext
                .MovieSessions.Include(ms => ms.Movie)
                .FirstOrDefaultAsync(ms => ms.MovieSessionId == movieSessionId);

            if (movieSession == null)
            {
                return NotFound("There is no such movieSession");
            }

            var currentDate = DateOnly.FromDateTime(DateTime.Now);

            if (movieSession.Movie.EndOfShow < currentDate)
            {
                return BadRequest("This movie session has already ended.");
            }

            var hall = await appDbContext.Halls.FirstOrDefaultAsync();

            if (hall == null)
            {
                return NotFound("There is no such hall");
            }

            if (rowNumber > hall.NumberOfRows || rowNumber < 1)
            {
                return NotFound("There is no such row");
            }

            if (seatNumber > hall.NumberOfSeats || seatNumber < 1)
            {
                return NotFound("There is no such seat");
            }

            var price = await appDbContext
                .Prices.Include(m => m.Movie)
                .ThenInclude(ms => ms.MovieSessions)
                .Include(s => s.SeatReservation)
                .ThenInclude(h => h.Hall)
                .Where(p =>
                    p.Movie.MovieSessions.Any(ms => ms.MovieSessionId == movieSessionId)
                    && p.SeatReservation.RowNumber == rowNumber
                    && p.SeatReservation.SeatNumber == seatNumber
                )
                .Select(item => new
                {
                    item.PriceId,
                    MovieSessionID = item.Movie.MovieSessions.FirstOrDefault().MovieSessionId,
                    item.Movie.MovieTitle,
                    HallId = item.SeatReservation.Hall.HallId,
                    HallName = item.SeatReservation.Hall.HallName,
                    HallType = item.SeatReservation.Hall.HallType,
                    StartTime = item.Movie.MovieSessions.FirstOrDefault().StartTime,
                    item.SeatReservation.RowNumber,
                    item.SeatReservation.SeatNumber,
                    IsReserved = item.SeatReservation.IsReserved,
                    item.Price1
                })
                .ToListAsync();

            if (price.Any(p => p.IsReserved))
            {
                return BadRequest("The place is already reserved");
            }

            var seatReservationToUpdate = await appDbContext
                .SeatReservations.Include(h => h.Hall)
                .FirstOrDefaultAsync(sr =>
                    sr.RowNumber == rowNumber
                    && sr.SeatNumber == seatNumber
                    && sr.HallId == price.FirstOrDefault().HallId
                );

            if (seatReservationToUpdate != null)
            {
                seatReservationToUpdate.IsReserved = true;
                await appDbContext.SaveChangesAsync();
            }

            var reservation = new Reservation
            {
                UserId = user.UserId,
                MovieSessionId = movieSessionId,
                PriceId = price.FirstOrDefault().PriceId
            };

            appDbContext.Reservations.Add(reservation);
            await appDbContext.SaveChangesAsync();

            var returnReservation = await appDbContext.Reservations.FindAsync(
                reservation.ReservationId
            );

            return Ok(returnReservation);
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<Reservation>> onPatchAsync(
            int id,
            [FromBody] ReservationPatchDTO reservation
        )
        {
            var reservationToUpdate = await appDbContext.Reservations.FindAsync(id);

            if (reservationToUpdate == null)
            {
                return NotFound();
            }

            if (reservation.UserId.HasValue)
            {
                var user = await appDbContext.Users.FindAsync(reservation.UserId.Value);

                if (user == null)
                {
                    return NotFound("User not found");
                }
                reservationToUpdate.UserId = reservation.UserId.Value;
            }

            if (reservation.MovieSessionId.HasValue)
            {
                var movieSession = await appDbContext.MovieSessions.FirstOrDefaultAsync(ms =>
                    ms.MovieSessionId == reservation.MovieSessionId.Value
                );

                if (movieSession == null)
                {
                    return NotFound("There is no such movieSession");
                }

                var movieSessionCheck = await appDbContext
                    .MovieSessions.Include(m => m.Movie)
                    .ThenInclude(p => p.Prices)
                    .Where(m =>
                        m.MovieId == movieSession.MovieId
                        && m.Movie.Prices.Any(p => p.PriceId == reservation.PriceId)
                    )
                    .ToListAsync();

                if (movieSessionCheck.Count == 0)
                {
                    return NotFound("There is no such movieSession in this priceId");
                }
                reservationToUpdate.MovieSessionId = reservation.MovieSessionId.Value;
            }

            if (reservation.PriceId.HasValue)
            {
                var existingReservationWithSamePriceId =
                    await appDbContext.Reservations.FirstOrDefaultAsync(r =>
                        r.PriceId == reservation.PriceId.Value && r.ReservationId != id
                    );

                if (existingReservationWithSamePriceId != null)
                {
                    return BadRequest("PriceId is already used in another reservation.");
                }
                reservationToUpdate.PriceId = reservation.PriceId.Value;
            }

            await appDbContext.SaveChangesAsync();

            return Ok(reservationToUpdate);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservation>> onDeleteAsync(int id)
        {
            var reservation = await appDbContext.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            var price = await appDbContext
                .Prices.Include(p => p.SeatReservation)
                .FirstOrDefaultAsync(p => p.PriceId == reservation.PriceId);

            if (price != null)
            {
                price.SeatReservation.IsReserved = false;
                await appDbContext.SaveChangesAsync();
            }

            appDbContext.Reservations.Remove(reservation);
            await appDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
