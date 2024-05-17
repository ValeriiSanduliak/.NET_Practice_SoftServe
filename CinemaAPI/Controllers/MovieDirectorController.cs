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
    public class MovieDirectorController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public MovieDirectorController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDirector>>> onGetAsync()
        {
            var movieDirectors = await appDbContext.MovieDirectors.ToListAsync();

            var result = movieDirectors
                .Select(item => new
                {
                    item.MovieDirectorId,
                    item.DirectorId,
                    item.MovieId
                })
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDirector>> onGetMovieDirectorAsync(int id)
        {
            var movieDirector = await appDbContext.MovieDirectors.FindAsync(id);
            if (movieDirector == null)
            {
                return NotFound();
            }
            var result = new
            {
                movieDirector.MovieDirectorId,
                movieDirector.DirectorId,
                movieDirector.MovieId
            };
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDirector>> onPostAsync(
            [FromBody] MovieDirectorDTO movieDirectorDTO
        )
        {
            var existingMovie = await appDbContext.Movies.FindAsync(movieDirectorDTO.MovieId);
            if (existingMovie == null)
            {
                return NotFound("Movie not found.");
            }
            var existingDirector = await appDbContext.Directors.FindAsync(
                movieDirectorDTO.DirectorId
            );
            if (existingDirector == null)
            {
                return NotFound("Director not found.");
            }

            var existingMovieDirector = await appDbContext
                .MovieDirectors.Where(md =>
                    md.MovieId == movieDirectorDTO.MovieId
                    && md.DirectorId == movieDirectorDTO.DirectorId
                )
                .FirstOrDefaultAsync();

            if (existingMovieDirector != null)
            {
                return Conflict("This director is already associated with this movie.");
            }

            var movieDirector = new MovieDirector
            {
                DirectorId = movieDirectorDTO.DirectorId,
                MovieId = movieDirectorDTO.MovieId
            };

            appDbContext.MovieDirectors.Add(movieDirector);
            await appDbContext.SaveChangesAsync();
            var createdMovieDirector = await appDbContext.MovieDirectors.FindAsync(
                movieDirector.MovieDirectorId
            );

            return StatusCode(201, createdMovieDirector);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<MovieDirector>> onPatchAsync(
            int id,
            [FromBody] MovieDirectorDTO movieDirectorDTO
        )
        {
            var movieDirector = await appDbContext.MovieDirectors.FindAsync(id);
            if (movieDirector == null)
            {
                return NotFound();
            }

            var existingMovie = await appDbContext.Movies.FindAsync(movieDirectorDTO.MovieId);
            if (existingMovie == null)
            {
                return NotFound("Movie not found.");
            }

            var existingDirectorB = await appDbContext.Directors.FindAsync(
                movieDirectorDTO.DirectorId
            );
            if (existingDirectorB == null)
            {
                return NotFound("Director not found.");
            }

            var existingDirector = await appDbContext.MovieDirectors.FirstOrDefaultAsync(md =>
                md.MovieId == movieDirectorDTO.MovieId
                && md.DirectorId == movieDirectorDTO.DirectorId
            );

            if (existingDirector != null && existingDirector.MovieDirectorId != id)
            {
                return Conflict("This director is already associated with this movie.");
            }

            movieDirector.DirectorId = movieDirectorDTO.DirectorId;
            movieDirector.MovieId = movieDirectorDTO.MovieId;

            await appDbContext.SaveChangesAsync();

            var result = new
            {
                movieDirector.MovieDirectorId,
                movieDirector.DirectorId,
                movieDirector.MovieId
            };
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieDirector>> onDeleteAsync(int id)
        {
            var movieDirector = await appDbContext.MovieDirectors.FindAsync(id);
            if (movieDirector == null)
            {
                return NotFound();
            }

            appDbContext.MovieDirectors.Remove(movieDirector);
            await appDbContext.SaveChangesAsync();

            var result = new
            {
                movieDirector.MovieDirectorId,
                movieDirector.DirectorId,
                movieDirector.MovieId
            };

            return Ok(result);
        }
    }
}
