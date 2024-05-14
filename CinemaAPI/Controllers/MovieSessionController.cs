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
        public async Task<ActionResult<List<MovieSession>>> onGetAsync()
        {
            var movieSessions = await appDbContext.MovieSessions.ToListAsync();
            return Ok(movieSessions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieSession>> onGetMovieSessionAsync(int id)
        {
            var movieSession = await appDbContext.MovieSessions.FindAsync(id);
            if (movieSession == null)
            {
                return NotFound();
            }
            return Ok(movieSession);
        }

        //[Authorize(Roles = "admin")]
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

        //[Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<MovieSession>> onPutAsync(
            int id,
            [FromBody] MovieSession movieSession
        )
        {
            if (id != movieSession.MovieSessionId)
            {
                return BadRequest();
            }

            appDbContext.Entry(movieSession).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();

            return NoContent();
        }

        //[Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieSession>> onDeleteAsync(int id)
        {
            var movieSession = await appDbContext.MovieSessions.FindAsync(id);
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
