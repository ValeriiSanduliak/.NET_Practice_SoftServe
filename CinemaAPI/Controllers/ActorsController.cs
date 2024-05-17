using System;
using System.Reflection.Metadata.Ecma335;
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
    public class ActorsController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public ActorsController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> onGetAsync()
        {
            var actors = await appDbContext
                .Actors.Include(a => a.MovieActors)
                .ThenInclude(ma => ma.Movie)
                .ToListAsync();

            if (actors == null)
            {
                return NoContent();
            }

            var actorDTOs = actors
                .Select(actor => new ActorDTO
                {
                    ActorId = actor.ActorId,
                    ActorFullName = actor.ActorFullName,
                    ActorPhoto = actor.ActorPhoto,
                    ActorBirthday = actor.ActorBirthday,
                    ActorCountry = actor.ActorCountry,
                    ActorHeight = actor.ActorHeight,
                    Movies = actor
                        .MovieActors.Select(ma => new MovieActorList
                        {
                            MovieId = ma.MovieId,
                            MovieTitle = ma.Movie.MovieTitle,
                            RoleName = ma.ActorNickname
                        })
                        .ToList()
                })
                .ToList();

            return Ok(actorDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDTO>> onGetAsync(int id)
        {
            var actor = await appDbContext
                .Actors.Include(a => a.MovieActors)
                .ThenInclude(ma => ma.Movie)
                .FirstOrDefaultAsync(a => a.ActorId == id);

            if (actor == null)
            {
                return NotFound();
            }

            var actorDTO = new ActorDTO
            {
                ActorId = actor.ActorId,
                ActorFullName = actor.ActorFullName,
                ActorPhoto = actor.ActorPhoto,
                ActorBirthday = actor.ActorBirthday,
                ActorCountry = actor.ActorCountry,
                ActorHeight = actor.ActorHeight,
                Movies = actor
                    .MovieActors.Select(ma => new MovieActorList
                    {
                        MovieId = ma.MovieId,
                        MovieTitle = ma.Movie.MovieTitle,
                        RoleName = ma.ActorNickname
                    })
                    .ToList()
            };

            return Ok(actorDTO);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<ActorPostDTO>> onPostAsync([FromBody] ActorPostDTO actorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actor = new Actor
            {
                ActorFullName = actorDTO.ActorFullName,
                ActorPhoto = actorDTO.ActorPhoto,
                ActorBirthday = actorDTO.ActorBirthday,
                ActorCountry = actorDTO.ActorCountry,
                ActorHeight = actorDTO.ActorHeight
            };

            appDbContext.Actors.Add(actor);
            await appDbContext.SaveChangesAsync();

            var createdActor = await appDbContext.Actors.FindAsync(actor.ActorId);

            if (createdActor != null)
            {
                //return CreatedAtAction(
                //    "onGetActorAsync",
                //    new { id = createdActor.ActorId },
                //    createdActor
                //);
                return StatusCode(201, createdActor);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<ActorPatchDTO>> OnPatchAsync(
            int id,
            [FromBody] ActorPatchDTO actorPatchDTO
        )
        {
            try
            {
                var existingActor = await appDbContext.Actors.FindAsync(id);
                if (existingActor == null)
                {
                    return NotFound();
                }

                if (actorPatchDTO.ActorFullName != null)
                {
                    existingActor.ActorFullName = actorPatchDTO.ActorFullName;
                }

                if (actorPatchDTO.ActorBirthday != null)
                {
                    existingActor.ActorBirthday = actorPatchDTO.ActorBirthday;
                }

                if (actorPatchDTO.ActorCountry != null)
                {
                    existingActor.ActorCountry = actorPatchDTO.ActorCountry;
                }

                if (actorPatchDTO.ActorHeight != null)
                {
                    existingActor.ActorHeight = actorPatchDTO.ActorHeight;
                }

                await appDbContext.SaveChangesAsync();
                return Ok(existingActor);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency conflict
                return Conflict("The actor has been modified or deleted by another process.");
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Actor>> onDeleteAsync(int id)
        {
            var actor = await appDbContext
                .Actors.Include(a => a.MovieActors)
                .FirstOrDefaultAsync(a => a.ActorId == id);

            if (actor == null)
            {
                return NotFound();
            }
            appDbContext.Actors.Remove(actor);
            await appDbContext.SaveChangesAsync();
            return Ok(actor);
        }
    }
}
