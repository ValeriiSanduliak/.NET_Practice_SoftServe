using System.IdentityModel.Tokens.Jwt;
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
    public class ReservationController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public ReservationController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

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

            JwtSecurityToken jwt = handler.ReadJwtToken(token);

            string email =
                jwt.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value ?? string.Empty;

            // Find the user by email
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.UserEmail == email);

            if (user == null)
            {
                // User with this email does not exist
                return NotFound("User not found");
            }

            var moviesession = await appDbContext.MovieSessions.FindAsync(movieSessionId);
            if (moviesession == null)
            {
                return NotFound("There is no such movieSession");
            }

            var hall = await appDbContext.Halls.FirstOrDefaultAsync();

            if (hall == null)
            {
                return NotFound("There is no such hall");
            }

            if (rowNumber > hall.NumberOfRows)
            {
                return NotFound("There is no such row");
            }

            if (seatNumber > hall.NumberOfSeats)
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

            return Ok();
        }
    }
}
