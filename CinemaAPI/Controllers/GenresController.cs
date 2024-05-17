using System.IO;
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
    public class GenresController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public GenresController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDTO>>> onGetAsync()
        {
            var genres = await appDbContext.Genres.ToListAsync();

            if (genres == null)
            {
                return NoContent();
            }

            var genreDTOs = genres
                .Select(genre => new GenreDTO
                {
                    GenreId = genre.GenreId,
                    GenreName = genre.GenreName
                })
                .ToList();

            return Ok(genreDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> onGetGenreAsync(int id)
        {
            var genre = await appDbContext
                .Genres.Select(genre => new GenreDTO
                {
                    GenreId = genre.GenreId,
                    GenreName = genre.GenreName
                })
                .FirstOrDefaultAsync(genre => genre.GenreId == id);

            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<GenrePostDTO>> onPostAsync(
            [FromBody] GenrePostDTO genrePostDTO
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newGenre = new Genre { GenreName = genrePostDTO.GenreName };

            appDbContext.Genres.Add(newGenre);
            await appDbContext.SaveChangesAsync();

            var createdGenre = await appDbContext.Genres.FindAsync(newGenre.GenreId);

            if (createdGenre != null)
            {
                //return CreatedAtAction(
                //    nameof(onPostAsync),
                //    new { id = createdGenre.GenreId },
                //    createdGenre
                //);
                return StatusCode(201, createdGenre);
            }
            else
            {
                return BadRequest("Error creating genre.");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<GenrePostDTO>> OnPatchAsync(
            int id,
            [FromBody] GenrePostDTO genrePatchDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingGenre = await appDbContext.Genres.FindAsync(id);
                if (existingGenre == null)
                {
                    return NotFound();
                }

                if (genrePatchDTO.GenreName != null)
                {
                    existingGenre.GenreName = genrePatchDTO.GenreName;
                }

                await appDbContext.SaveChangesAsync();
                return Ok(existingGenre);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(
                    "The genrePatchDTO has been modified or deleted by another process."
                );
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> onDeleteAsync(int id)
        {
            var genre = await appDbContext
                .Genres.Include(a => a.MovieGenres)
                .FirstOrDefaultAsync(a => a.GenreId == id);

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
