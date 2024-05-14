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
    public class ScreenwrittersController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public ScreenwrittersController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Screenwriter>>> onGetAsync()
        {
            var screenwriters = await appDbContext.Screenwriters.ToListAsync();
            return Ok(screenwriters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Screenwriter>> onGetScreenwriterAsync(int id)
        {
            var screenwriter = await appDbContext.Screenwriters.FindAsync(id);
            if (screenwriter == null)
            {
                return NotFound();
            }
            return Ok(screenwriter);
        }

        [HttpPost]
        public async Task<ActionResult<Screenwriter>> onPostAsync(
            [FromBody] Screenwriter screenwriter
        )
        {
            appDbContext.Screenwriters.Add(screenwriter);
            await appDbContext.SaveChangesAsync();
            var createdScreenwriter = await appDbContext.Screenwriters.FindAsync(
                screenwriter.ScreenwriterId
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
        public async Task<ActionResult<Screenwriter>> OnPatchAsync(
            int id,
            [FromBody] Screenwriter screenwriter
        )
        {
            try
            {
                var existingScreenwriter = await appDbContext.Screenwriters.FindAsync(id);
                if (existingScreenwriter == null)
                {
                    return NotFound();
                }

                // Update the existing Screenwriter entity with the values from the incoming entity
                if (screenwriter.ScreenwriterFullName != null)
                {
                    existingScreenwriter.ScreenwriterFullName = screenwriter.ScreenwriterFullName;
                }

                await appDbContext.SaveChangesAsync();
                return Ok(existingScreenwriter);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency conflict
                return Conflict(
                    "The Screenwriter has been modified or deleted by another process."
                );
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Screenwriter>> onDeleteAsync(int id)
        {
            var screenwriter = await appDbContext.Screenwriters.FindAsync(id);
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
