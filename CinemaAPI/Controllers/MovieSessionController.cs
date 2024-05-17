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
    public class MovieSessionController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public MovieSessionController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieSessionDTO>>> onGetAsync()
        {
            var movieSessions = await appDbContext
                .MovieSessions.Include(ms => ms.Movie)
                .Include(ms => ms.Hall)
                .Include(ms => ms.Reservations)
                .ToListAsync();

            if (movieSessions == null)
            {
                return NoContent();
            }

            var movieSessionDTOs = movieSessions
                .Select(movieSession => new MovieSessionDTO
                {
                    MovieSessionId = movieSession.MovieSessionId,
                    StartTime = movieSession.StartTime,
                    TheLowestPrice = movieSession.TheLowestPrice,
                    MiddlePrice = movieSession.MiddlePrice,
                    TheHighestPrice = movieSession.TheHighestPrice,
                    Movie = new EntityWithMovieList
                    {
                        MovieId = movieSession.MovieId,
                        MovieTitle = movieSession.Movie.MovieTitle
                    },
                    Hall = new EntityWithHallList
                    {
                        HallId = movieSession.HallId,
                        HallName = movieSession.Hall.HallName,
                        HallType = movieSession.Hall.HallType,
                        NumberOfRows = movieSession.Hall.NumberOfRows,
                        NumberOfSeats = movieSession.Hall.NumberOfSeats
                    },
                    Reservations = movieSession
                        .Reservations.Select(r => new EntityWithReservation
                        {
                            ReservationId = r.ReservationId,
                            PriceId = r.PriceId,
                            MovieSessionId = r.MovieSessionId,
                            UserId = r.UserId,
                        })
                        .ToList()
                })
                .ToList();

            return Ok(movieSessionDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieSessionDTO>> onGetMovieSessionAsync(int id)
        {
            var movieSession = await appDbContext
                .MovieSessions.Include(ms => ms.Movie)
                .Include(ms => ms.Hall)
                .Include(ms => ms.Reservations)
                .FirstOrDefaultAsync(ms => ms.MovieSessionId == id);

            if (movieSession == null)
            {
                return NotFound();
            }

            var movieSessionDTO = new MovieSessionDTO
            {
                MovieSessionId = movieSession.MovieSessionId,
                StartTime = movieSession.StartTime,
                TheLowestPrice = movieSession.TheLowestPrice,
                MiddlePrice = movieSession.MiddlePrice,
                TheHighestPrice = movieSession.TheHighestPrice,
                Movie = new EntityWithMovieList
                {
                    MovieId = movieSession.MovieId,
                    MovieTitle = movieSession.Movie.MovieTitle
                },
                Hall = new EntityWithHallList
                {
                    HallId = movieSession.HallId,
                    HallName = movieSession.Hall.HallName,
                    HallType = movieSession.Hall.HallType,
                    NumberOfRows = movieSession.Hall.NumberOfRows,
                    NumberOfSeats = movieSession.Hall.NumberOfSeats
                },
                Reservations = movieSession
                    .Reservations.Select(r => new EntityWithReservation
                    {
                        ReservationId = r.ReservationId,
                        PriceId = r.PriceId,
                        MovieSessionId = r.MovieSessionId,
                        UserId = r.UserId,
                    })
                    .ToList()
            };

            return Ok(movieSessionDTO);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<MovieSessionPostDTO>> onPostAsync(
            [FromBody] MovieSessionPostDTO movieSessionDTO
        )
        {
            var movieSession = new MovieSession
            {
                HallId = movieSessionDTO.HallId,
                MovieId = movieSessionDTO.MovieId,
                StartTime = movieSessionDTO.StartTime,
                TheLowestPrice = movieSessionDTO.TheLowestPrice,
                MiddlePrice = movieSessionDTO.MiddlePrice,
                TheHighestPrice = movieSessionDTO.TheHighestPrice
            };

            appDbContext.MovieSessions.Add(movieSession);
            await appDbContext.SaveChangesAsync();
            var createdMovieSession = await appDbContext.MovieSessions.FindAsync(
                movieSession.MovieSessionId
            );

            if (createdMovieSession != null)
            {
                //return CreatedAtAction(
                //    "onGetMovieSessionAsync",
                //    new { id = createdMovieSession.MovieSessionId },
                //    createdMovieSession
                //);
                return StatusCode(201, createdMovieSession);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<MovieSessionPatchDTO>> onPutAsync(
            int id,
            [FromBody] MovieSessionPatchDTO movieSessionPatchDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingMovieSession = await appDbContext.MovieSessions.FindAsync(id);
                if (existingMovieSession == null)
                {
                    return NotFound();
                }

                if (movieSessionPatchDTO.HallId != null)
                {
                    existingMovieSession.HallId = (int)movieSessionPatchDTO.HallId;
                }

                if (movieSessionPatchDTO.MovieId != null)
                {
                    existingMovieSession.MovieId = (int)movieSessionPatchDTO.MovieId;
                }

                if (movieSessionPatchDTO.StartTime != null)
                {
                    existingMovieSession.StartTime = (TimeOnly)movieSessionPatchDTO.StartTime;
                }

                if (movieSessionPatchDTO.TheLowestPrice != null)
                {
                    existingMovieSession.TheLowestPrice = movieSessionPatchDTO.TheLowestPrice;
                }

                if (movieSessionPatchDTO.MiddlePrice != null)
                {
                    existingMovieSession.MiddlePrice = movieSessionPatchDTO.MiddlePrice;
                }

                if (movieSessionPatchDTO.TheHighestPrice != null)
                {
                    existingMovieSession.TheHighestPrice = movieSessionPatchDTO.TheHighestPrice;
                }

                await appDbContext.SaveChangesAsync();

                return Ok(existingMovieSession);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieSession>> onDeleteAsync(int id)
        {
            var movieSession = await appDbContext
                .MovieSessions.Include(ms => ms.Reservations)
                .FirstOrDefaultAsync(ms => ms.MovieSessionId == id);

            if (movieSession == null)
            {
                return NotFound();
            }

            appDbContext.MovieSessions.Remove(movieSession);
            await appDbContext.SaveChangesAsync();

            return Ok(movieSession);
        }
    }
}
