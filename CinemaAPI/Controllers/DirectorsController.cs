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
    public class DirectorsController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public DirectorsController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Director>>> onGetAsync()
        {
            var directors = await appDbContext.Directors.ToListAsync();
            return Ok(directors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> onGetDirectorAsync(int id)
        {
            var director = await appDbContext.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }

        [HttpPost]
        public async Task<ActionResult<Director>> onPostAsync([FromBody] Director director)
        {
            appDbContext.Directors.Add(director);
            await appDbContext.SaveChangesAsync();
            var createdDirector = await appDbContext.Directors.FindAsync(director.DirectorId);

            if (createdDirector != null)
            {
                return StatusCode(201, createdDirector);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Director>> OnPatchAsync(int id, [FromBody] Director director)
        {
            try
            {
                var existingDirector = await appDbContext.Directors.FindAsync(id);
                if (existingDirector == null)
                {
                    return NotFound();
                }

                // Update the existing Director entity with the values from the incoming entity
                if (director.DirectorFullName != null)
                {
                    existingDirector.DirectorFullName = director.DirectorFullName;
                }

                await appDbContext.SaveChangesAsync();
                return Ok(existingDirector);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency conflict
                return Conflict("The Director has been modified or deleted by another process.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Director>> onDeleteAsync(int id)
        {
            var director = await appDbContext.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            appDbContext.Directors.Remove(director);
            await appDbContext.SaveChangesAsync();
            return Ok(director);
        }
    }
}
