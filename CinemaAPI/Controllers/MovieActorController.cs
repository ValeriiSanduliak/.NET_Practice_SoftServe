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
    public class MovieActorController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public MovieActorController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<List<MovieActor>>> onGetAsync()
        {
            var movieActors = await appDbContext
                .MovieActors.Select(item => new
                {
                    item.MovieActorId,
                    item.ActorId,
                    item.MovieId,
                    item.ActorNickname
                })
                .ToListAsync();
            return Ok(movieActors);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieActor>> onGetMovieActorAsync(int id)
        {
            var movieActor = await appDbContext.MovieActors.FindAsync(id);
            if (movieActor == null)
            {
                return NotFound();
            }
            var returnMovieActor = new
            {
                movieActor.MovieActorId,
                movieActor.ActorId,
                movieActor.MovieId,
                movieActor.ActorNickname
            };
            return Ok(returnMovieActor);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<MovieActor>> onPostAsync(
            [FromBody] MovieActorPostDTO movieActorDTO
        )
        {
            var existingMovie = await appDbContext.Movies.FindAsync(movieActorDTO.MovieId);
            if (existingMovie == null)
            {
                return NotFound("Movie not found.");
            }
            var existingActor = await appDbContext.Actors.FindAsync(movieActorDTO.ActorId);
            if (existingActor == null)
            {
                return NotFound("Actor not found.");
            }

            var movieActor = new MovieActor
            {
                ActorId = movieActorDTO.ActorId,
                MovieId = movieActorDTO.MovieId,
                ActorNickname = movieActorDTO.ActorNickname
            };

            appDbContext.MovieActors.Add(movieActor);
            await appDbContext.SaveChangesAsync();

            var createdMovieActor = await appDbContext.MovieActors.FindAsync(
                movieActor.MovieActorId
            );

            if (createdMovieActor != null)
            {
                var returnMovieActor = new
                {
                    createdMovieActor.MovieActorId,
                    createdMovieActor.ActorId,
                    createdMovieActor.MovieId,
                    createdMovieActor.ActorNickname
                };

                return StatusCode(201, returnMovieActor);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<MovieActor>> onPatchAsync(
            int id,
            [FromBody] MovieActorPatchDTO movieActorDTO
        )
        {
            var movieActor = await appDbContext.MovieActors.FindAsync(id);
            if (movieActor == null)
            {
                return NotFound();
            }

            if (movieActorDTO.MovieId.HasValue)
            {
                var existingMovie = await appDbContext.Movies.FindAsync(
                    movieActorDTO.MovieId.Value
                );
                if (existingMovie == null)
                {
                    return NotFound("Movie not found.");
                }
                movieActor.MovieId = movieActorDTO.MovieId.Value;
            }

            if (movieActorDTO.ActorId.HasValue)
            {
                var existingActor = await appDbContext.Actors.FindAsync(
                    movieActorDTO.ActorId.Value
                );
                if (existingActor == null)
                {
                    return NotFound("Actor not found.");
                }
                movieActor.ActorId = movieActorDTO.ActorId.Value;
            }

            if (movieActorDTO.ActorNickname != null)
            {
                movieActor.ActorNickname = movieActorDTO.ActorNickname;
            }

            var returnMovieActor = new
            {
                movieActor.MovieActorId,
                movieActor.ActorId,
                movieActor.MovieId,
                movieActor.ActorNickname
            };

            await appDbContext.SaveChangesAsync();
            return Ok(returnMovieActor);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieActor>> onDeleteAsync(int id)
        {
            var movieActor = await appDbContext.MovieActors.FindAsync(id);
            if (movieActor == null)
            {
                return NotFound();
            }

            appDbContext.MovieActors.Remove(movieActor);
            await appDbContext.SaveChangesAsync();

            return Ok(movieActor);
        }
    }
}
