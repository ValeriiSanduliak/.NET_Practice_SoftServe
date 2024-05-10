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
            var movieList = (
                from movie in appDbContext.Movies
                join movieDirector in appDbContext.MovieDirectors
                    on movie.MovieId equals movieDirector.MovieId
                join director in appDbContext.Directors
                    on movieDirector.DirectorId equals director.DirectorId
                join movieGenre in appDbContext.MovieGenres
                    on movie.MovieId equals movieGenre.MovieId
                join genre in appDbContext.Genres on movieGenre.GenreId equals genre.GenreId
                select new
                {
                    movie,
                    Director = new { director.DirectorFullName },
                    Genre = new { genre.GenreName }
                }
            ).ToList();
            var movieListWithActors = movieList
                .Select(item => new
                {
                    item.movie.MovieId,
                    item.movie.MovieTitle,
                    item.movie.Duration,
                    item.movie.Country,
                    item.movie.WorldPremiere,
                    item.movie.UkrainePremiere,
                    item.movie.Rating,
                    item.movie.EndOfShow,
                    item.movie.Limitations,
                    Actors = (
                        from movieActor in appDbContext.MovieActors
                        join actor in appDbContext.Actors on movieActor.ActorId equals actor.ActorId
                        where movieActor.MovieId == item.movie.MovieId
                        select new { actor.ActorFullName, actor.ActorPhoto }
                    ).ToList(),
                    item.Director,
                    item.Genre
                })
                .GroupBy(m => m.MovieTitle)
                .Select(g => g.First())
                .ToList();
            if (movieListWithActors == null)
            {
                return NotFound();
            }
            return Ok(movieListWithActors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Movie>>> onGetMovieAsync(int id)
        {
            var movieInfo = (
                from movie in appDbContext.Movies
                where movie.MovieId == id
                join movieDirector in appDbContext.MovieDirectors
                    on movie.MovieId equals movieDirector.MovieId
                join director in appDbContext.Directors
                    on movieDirector.DirectorId equals director.DirectorId
                join movieGenre in appDbContext.MovieGenres
                    on movie.MovieId equals movieGenre.MovieId
                join genre in appDbContext.Genres on movieGenre.GenreId equals genre.GenreId
                select new
                {
                    movie,
                    Director = new { director.DirectorFullName },
                    Genre = new { genre.GenreName }
                }
            ).FirstOrDefault();

            if (movieInfo == null)
            {
                return NotFound();
            }

            var movieWithActors = new
            {
                movieInfo.movie.MovieId,
                movieInfo.movie.MovieTitle,
                movieInfo.movie.Duration,
                movieInfo.movie.Country,
                movieInfo.movie.WorldPremiere,
                movieInfo.movie.UkrainePremiere,
                movieInfo.movie.Rating,
                movieInfo.movie.EndOfShow,
                movieInfo.movie.Limitations,
                Actors = (
                    from movieActor in appDbContext.MovieActors
                    join actor in appDbContext.Actors on movieActor.ActorId equals actor.ActorId
                    where movieActor.MovieId == movieInfo.movie.MovieId
                    select new { actor.ActorFullName, actor.ActorPhoto }
                ).ToList(),
                movieInfo.Director,
                movieInfo.Genre
            };

            return Ok(movieWithActors);
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

        [HttpPatch("{id}")]
        public async Task<ActionResult<Movie>> OnPatchAsync(int id, [FromBody] MovieDTO movie)
        {
            try
            {
                var existingMovie = await appDbContext.Movies.FindAsync(id);
                if (existingMovie == null)
                {
                    return NotFound();
                }

                // Update the existing actor entity with the values from the incoming entity
                if (movie.MovieTitle != null)
                {
                    existingMovie.MovieTitle = movie.MovieTitle;
                }

                if (movie.MediaId != null)
                {
                    existingMovie.MediaId = movie.MediaId;
                }

                if (movie.Duration != null)
                {
                    existingMovie.Duration = movie.Duration;
                }

                if (movie.Country != null)
                {
                    existingMovie.Country = movie.Country;
                }
                if (movie.WorldPremiere != null)
                {
                    existingMovie.WorldPremiere = movie.WorldPremiere;
                }
                if (movie.UkrainePremiere != null)
                {
                    existingMovie.UkrainePremiere = movie.UkrainePremiere;
                }
                if (movie.Rating != null)
                {
                    existingMovie.Rating = movie.Rating;
                }
                if (movie.EndOfShow != null)
                {
                    existingMovie.EndOfShow = movie.EndOfShow;
                }
                if (movie.Limitations != null)
                {
                    existingMovie.Limitations = movie.Limitations;
                }

                await appDbContext.SaveChangesAsync();
                return Ok(existingMovie);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency conflict
                return Conflict("The movie has been modified or deleted by another process.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> onDeleteAsync(int id)
        {
            var movie = await appDbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            appDbContext.Movies.Remove(movie);
            await appDbContext.SaveChangesAsync();
            return Ok(movie);
        }
    }
}
