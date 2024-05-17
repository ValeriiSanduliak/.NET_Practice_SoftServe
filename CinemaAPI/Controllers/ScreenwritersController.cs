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
    public class ScreenwritersController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public ScreenwritersController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<ScreenWriterWithMoviesDTO>>> onGetAsync()
        {
            var screenwriters = await appDbContext
                .Screenwriters.Include(d => d.MovieScreenwriters)
                .ThenInclude(md => md.Movie)
                .ToListAsync();

            if (screenwriters == null)
            {
                return NoContent();
            }

            var screenwriterDTOs = screenwriters
                .Select(screenwriter => new ScreenWriterWithMoviesDTO
                {
                    ScreenwriterId = screenwriter.ScreenwriterId,
                    ScreenwriterFullName = screenwriter.ScreenwriterFullName,
                    Movies = screenwriter
                        .MovieScreenwriters.Select(md => new EntityWithMovieList
                        {
                            MovieId = md.MovieId,
                            MovieTitle = md.Movie.MovieTitle
                        })
                        .ToList()
                })
                .ToList();

            return Ok(screenwriterDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Screenwriter>> onGetScreenwriterAsync(int id)
        {
            //var screenwriter = await appDbContext.Screenwriters.FindAsync(id);
            //if (screenwriter == null)
            //{
            //    return NotFound();
            //}
            //return Ok(screenwriter);
            var screenwriter = await appDbContext
                .Screenwriters.Include(d => d.MovieScreenwriters)
                .ThenInclude(md => md.Movie)
                .FirstOrDefaultAsync(d => d.ScreenwriterId == id);

            if (screenwriter == null)
            {
                return NotFound();
            }

            var screenwriterDTO = new ScreenWriterWithMoviesDTO
            {
                ScreenwriterId = screenwriter.ScreenwriterId,
                ScreenwriterFullName = screenwriter.ScreenwriterFullName,
                Movies = screenwriter
                    .MovieScreenwriters.Select(md => new EntityWithMovieList
                    {
                        MovieId = md.MovieId,
                        MovieTitle = md.Movie.MovieTitle
                    })
                    .ToList()
            };

            return Ok(screenwriterDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ScreenwriterPostDTO>> onPostAsync(
            [FromBody] ScreenwriterPostDTO screenwriterPostDTO
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newScreenwriter = new Screenwriter
            {
                ScreenwriterFullName = screenwriterPostDTO.ScreenwriterFullName
            };

            appDbContext.Screenwriters.Add(newScreenwriter);
            await appDbContext.SaveChangesAsync();

            var createdScreenwriter = await appDbContext.Screenwriters.FindAsync(
                newScreenwriter.ScreenwriterId
            );

            if (createdScreenwriter != null)
            {
                return StatusCode(201, createdScreenwriter);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ScreenwriterPostDTO>> OnPatchAsync(
            int id,
            [FromBody] ScreenwriterPostDTO screenwriterPatchDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingScreenwriter = await appDbContext.Screenwriters.FindAsync(id);
                if (existingScreenwriter == null)
                {
                    return NotFound();
                }

                if (screenwriterPatchDTO.ScreenwriterFullName != null)
                {
                    existingScreenwriter.ScreenwriterFullName =
                        screenwriterPatchDTO.ScreenwriterFullName;
                }

                await appDbContext.SaveChangesAsync();
                return Ok(existingScreenwriter);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(
                    "The Screenwriter has been modified or deleted by another process."
                );
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Screenwriter>> onDeleteAsync(int id)
        {
            var screenwriter = await appDbContext
                .Screenwriters.Include(a => a.MovieScreenwriters)
                .FirstOrDefaultAsync(a => a.ScreenwriterId == id);

            if (screenwriter == null)
            {
                return NotFound();
            }
            appDbContext.Screenwriters.Remove(screenwriter);
            await appDbContext.SaveChangesAsync();
            return Ok(screenwriter);
        }
    }
}
