using System;
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
                        .MovieActors.Select(ma => new MovieActorListDTO
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

        //[HttpGet]
        //public async Task<ActionResult<List<Actor>>> onGetAsync()
        //{
        //    var actors = await appDbContext.Actors.ToListAsync();

        //    return Ok(actors);
        //}

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
                    .MovieActors.Select(ma => new MovieActorListDTO
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
        public async Task<ActionResult<Actor>> onPostAsync([FromBody] Actor actor)
        {
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
        public async Task<ActionResult<Actor>> OnPatchAsync(int id, [FromBody] Actor actor)
        {
            try
            {
                var existingActor = await appDbContext.Actors.FindAsync(id);
                if (existingActor == null)
                {
                    return NotFound();
                }

                // Update the existing actor entity with the values from the incoming entity
                if (actor.ActorFullName != null)
                {
                    existingActor.ActorFullName = actor.ActorFullName;
                }

                if (actor.ActorBirthday != null)
                {
                    existingActor.ActorBirthday = actor.ActorBirthday;
                }

                if (actor.ActorCountry != null)
                {
                    existingActor.ActorCountry = actor.ActorCountry;
                }

                if (actor.ActorHeight != null)
                {
                    existingActor.ActorHeight = actor.ActorHeight;
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
            var actor = await appDbContext.Actors.FindAsync(id);
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
