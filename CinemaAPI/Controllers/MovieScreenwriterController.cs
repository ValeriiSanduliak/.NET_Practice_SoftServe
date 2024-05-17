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
    public class MovieScreenwriterController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public MovieScreenwriterController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieScreenwriter>>> onGetAsync()
        {
            var movieScreenwriters = await appDbContext.MovieScreenwriters.ToListAsync();

            var result = movieScreenwriters
                .Select(item => new
                {
                    item.MovieScreenwriterId,
                    item.ScreenwriterId,
                    item.MovieId
                })
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieScreenwriter>> onGetMovieScreenwriterAsync(int id)
        {
            var movieScreenwriter = await appDbContext.MovieScreenwriters.FindAsync(id);
            if (movieScreenwriter == null)
            {
                return NotFound();
            }
            var result = new
            {
                movieScreenwriter.MovieScreenwriterId,
                movieScreenwriter.ScreenwriterId,
                movieScreenwriter.MovieId
            };
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MovieScreenwriter>> onPostAsync(
            [FromBody] MovieScreenwriterDTO movieScreenwriterDTO
        )
        {
            var existingMovie = await appDbContext.Movies.FindAsync(movieScreenwriterDTO.MovieId);
            if (existingMovie == null)
            {
                return NotFound("Movie not found.");
            }
            var existingScreenwriter = await appDbContext.Screenwriters.FindAsync(
                movieScreenwriterDTO.ScreenwriterId
            );
            if (existingScreenwriter == null)
            {
                return NotFound("Screenwriter not found.");
            }

            var existingMovieScreenwriter =
                await appDbContext.MovieScreenwriters.FirstOrDefaultAsync(ms =>
                    ms.MovieId == movieScreenwriterDTO.MovieId
                    && ms.ScreenwriterId == movieScreenwriterDTO.ScreenwriterId
                );

            if (existingMovieScreenwriter != null)
            {
                return Conflict("This screenwriter is already associated with this movie.");
            }

            var movieScreenwriter = new MovieScreenwriter
            {
                ScreenwriterId = movieScreenwriterDTO.ScreenwriterId,
                MovieId = movieScreenwriterDTO.MovieId
            };

            appDbContext.MovieScreenwriters.Add(movieScreenwriter);
            await appDbContext.SaveChangesAsync();

            return Ok(movieScreenwriter);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<MovieScreenwriter>> onPatchAsync(
            int id,
            [FromBody] MovieScreenwriterDTO movieScreenwriterDTO
        )
        {
            var movieScreenwriter = await appDbContext.MovieScreenwriters.FindAsync(id);
            if (movieScreenwriter == null)
            {
                return NotFound();
            }

            var existingMovie = await appDbContext.Movies.FindAsync(movieScreenwriterDTO.MovieId);
            if (existingMovie == null)
            {
                return NotFound("Movie not found.");
            }

            var existingScreenwriter = await appDbContext.Screenwriters.FindAsync(
                movieScreenwriterDTO.ScreenwriterId
            );
            if (existingScreenwriter == null)
            {
                return NotFound("Screenwriter not found.");
            }

            var existingMovieScreenwriter =
                await appDbContext.MovieScreenwriters.FirstOrDefaultAsync(ms =>
                    ms.MovieId == movieScreenwriterDTO.MovieId
                    && ms.ScreenwriterId == movieScreenwriterDTO.ScreenwriterId
                    && ms.MovieScreenwriterId != id
                );

            if (existingMovieScreenwriter != null)
            {
                return Conflict("This screenwriter is already associated with this movie.");
            }

            movieScreenwriter.ScreenwriterId = movieScreenwriterDTO.ScreenwriterId;
            movieScreenwriter.MovieId = movieScreenwriterDTO.MovieId;

            await appDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieScreenwriter>> onDeleteAsync(int id)
        {
            var movieScreenwriter = await appDbContext.MovieScreenwriters.FindAsync(id);
            if (movieScreenwriter == null)
            {
                return NotFound();
            }

            appDbContext.MovieScreenwriters.Remove(movieScreenwriter);
            await appDbContext.SaveChangesAsync();

            return Ok(movieScreenwriter);
        }
    }
}
