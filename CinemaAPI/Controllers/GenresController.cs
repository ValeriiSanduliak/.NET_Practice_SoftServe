using System.IO;
using CinemaAPI.Data;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public GenresController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> onGetAsync()
        {
            var genres = await appDbContext.Genres.ToListAsync();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> onGetGenreAsync(int id)
        {
            var genre = await appDbContext.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> onPostAsync([FromBody] Genre genre)
        {
            appDbContext.Genres.Add(genre);
            await appDbContext.SaveChangesAsync();
            var createdGenre = await appDbContext.Genres.FindAsync(genre.GenreId);

            if (createdGenre != null)
            {
                return StatusCode(201, createdGenre);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Genre>> OnPatchAsync(int id, [FromBody] Genre genre)
        {
            try
            {
                var existingGenre = await appDbContext.Genres.FindAsync(id);
                if (existingGenre == null)
                {
                    return NotFound();
                }

                // Update the existing genre entity with the values from the incoming entity
                if (genre.GenreName != null)
                {
                    existingGenre.GenreName = genre.GenreName;
                }

                await appDbContext.SaveChangesAsync();
                return Ok(existingGenre);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency conflict
                return Conflict("The genre has been modified or deleted by another process.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> onDeleteAsync(int id)
        {
            var genre = await appDbContext.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            appDbContext.Genres.Remove(genre);
            await appDbContext.SaveChangesAsync();
            return Ok(genre);
        }
    }
}
