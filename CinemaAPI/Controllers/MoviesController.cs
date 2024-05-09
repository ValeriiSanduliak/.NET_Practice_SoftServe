using System.Linq;
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
    public class MovieController : ControllerBase
    {
        private readonly CinemaDbContext appDbContext;

        public MovieController(CinemaDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> onGetAsync()
        {
            var movies = await appDbContext
                .MovieActors.Include(actor => actor.Actor)
                .Include(m => m.Movie)
                .ToListAsync();
            /*var movies = await appDbContext.Movies.ToListAsync();*/
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Movie>>> onGetMovieAsync(int id)
        {
            var movies = await appDbContext
                .MovieActors.Include(actor => actor.Actor)
                .Include(m => m.Movie)
                .Where(m => m.MovieId == id)
                .ToListAsync();

            var directors = await appDbContext
                .MovieDirectors.Include(director => director.Director)
                .Where(m => m.MovieId == id)
                .ToListAsync();

            var movieGenres = await appDbContext
                .MovieGenres.Include(genre => genre.Genre)
                .Where(m => m.MovieId == id)
                .ToListAsync();
            if (movies == null)
            {
                return NotFound();
            }
            else if (directors == null)
            {
                return NotFound();
            }
            else if (movieGenres == null)
            {
                return NotFound();
            }
            var combinedData = movies.Cast<object>().Concat(directors.Cast<object>()).ToList();

            return Ok(combinedData);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> onPostAsync([FromBody] MovieDTO movieDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Мапуємо об'єкт MovieDTO на об'єкт Movie
                    var movie = new Movie
                    {
                        MovieTitle = movieDto.MovieTitle,
                        MediaId = movieDto.MediaId,
                        Duration = movieDto.Duration,
                        Country = movieDto.Country,
                        WorldPremiere = movieDto.WorldPremiere,
                        UkrainePremiere = movieDto.UkrainePremiere,
                        Rating = movieDto.Rating,
                        EndOfShow = movieDto.EndOfShow,
                        Limitations = movieDto.Limitations,
                    };

                    // Додаємо фільм до контексту бази даних
                    appDbContext.Movies.Add(movie);
                    // Зберігаємо зміни
                    await appDbContext.SaveChangesAsync();
                    var createdMovie = await appDbContext.Movies.FindAsync(movie.MovieId);
                    // Повертаємо статус успішного створення об'єкта з його ідентифікатором
                    return StatusCode(201, createdMovie);
                }
                catch (Exception ex)
                {
                    // Повертаємо статус серверної помилки, якщо сталася помилка під час створення фільму
                    return StatusCode(500, ex);
                }
            }
            else
            {
                // Повертаємо статус помилки валідації, якщо дані у запиті невірні
                return BadRequest(ModelState);
            }
        }
    }
}
