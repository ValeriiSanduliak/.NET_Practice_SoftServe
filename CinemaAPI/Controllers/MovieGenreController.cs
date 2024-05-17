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
    public class MovieGenreController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public MovieGenreController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieGenre>>> onGetAsync()
        {
            var movieGenres = await appDbContext.MovieGenres.ToListAsync();

            var result = movieGenres
                .Select(item => new
                {
                    item.MovieGenreId,
                    item.GenreId,
                    item.MovieId
                })
                .ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieGenre>> onGetMovieGenreAsync(int id)
        {
            var movieGenre = await appDbContext.MovieGenres.FindAsync(id);
            if (movieGenre == null)
            {
                return NotFound();
            }
            var result = new
            {
                movieGenre.MovieGenreId,
                movieGenre.GenreId,
                movieGenre.MovieId
            };
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MovieGenre>> onPostAsync(
            [FromBody] MovieGenreDTO movieGenreDTO
        )
        {
            var existingMovie = await appDbContext.Movies.FindAsync(movieGenreDTO.MovieId);
            if (existingMovie == null)
            {
                return NotFound("Movie not found.");
            }

            var existingGenre = await appDbContext.Genres.FindAsync(movieGenreDTO.GenreId);
            if (existingGenre == null)
            {
                return NotFound("Genre not found.");
            }

            var existingMovieGenre = await appDbContext.MovieGenres.FirstOrDefaultAsync(mg =>
                mg.MovieId == movieGenreDTO.MovieId && mg.GenreId == movieGenreDTO.GenreId
            );
            if (existingMovieGenre != null)
            {
                return Conflict("This genre is already associated with this movie.");
            }

            var movieGenre = new MovieGenre
            {
                GenreId = movieGenreDTO.GenreId,
                MovieId = movieGenreDTO.MovieId
            };

            appDbContext.MovieGenres.Add(movieGenre);
            await appDbContext.SaveChangesAsync();
            return Ok(existingMovie);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<MovieGenre>> onPatchAsync(
            int id,
            [FromBody] MovieGenreDTO movieGenreDTO
        )
        {
            var movieGenre = await appDbContext.MovieGenres.FindAsync(id);
            if (movieGenre == null)
            {
                return NotFound();
            }

            var existingMovie = await appDbContext.Movies.FindAsync(movieGenreDTO.MovieId);
            if (existingMovie == null)
            {
                return NotFound("Movie not found.");
            }

            var existingGenre = await appDbContext.Genres.FindAsync(movieGenreDTO.GenreId);
            if (existingGenre == null)
            {
                return NotFound("Genre not found.");
            }

            var existingMovieGenre = await appDbContext.MovieGenres.FirstOrDefaultAsync(mg =>
                mg.MovieId == movieGenreDTO.MovieId
                && mg.GenreId == movieGenreDTO.GenreId
                && mg.MovieGenreId != id
            );

            if (existingMovieGenre != null)
            {
                return Conflict("This genre is already associated with this movie.");
            }

            movieGenre.GenreId = movieGenreDTO.GenreId;
            movieGenre.MovieId = movieGenreDTO.MovieId;

            await appDbContext.SaveChangesAsync();
            return Ok(movieGenre);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieGenre>> onDeleteAsync(int id)
        {
            var movieGenre = await appDbContext.MovieGenres.FindAsync(id);
            if (movieGenre == null)
            {
                return NotFound();
            }

            appDbContext.MovieGenres.Remove(movieGenre);
            await appDbContext.SaveChangesAsync();
            return Ok(movieGenre);
        }
    }
}
