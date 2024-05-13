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
                join MovieScreenwriter in appDbContext.MovieScreenwriters
                    on movie.MovieId equals MovieScreenwriter.MovieId
                join Screenwriter in appDbContext.Screenwriters
                    on MovieScreenwriter.ScreenwriterId equals Screenwriter.ScreenwriterId
                join Media in appDbContext.Media on movie.MediaId equals Media.MediaId
                select new { movie }
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

                    Director = string.Join(
                        ", ",
                        (
                            from movieDirector in appDbContext.MovieDirectors
                            join director in appDbContext.Directors
                                on movieDirector.DirectorId equals director.DirectorId
                            where movieDirector.MovieId == item.movie.MovieId
                            select director.DirectorFullName
                        )
                    ),
                    Genre = string.Join(
                        ", ",
                        (
                            from movieGenre in appDbContext.MovieGenres
                            join genre in appDbContext.Genres
                                on movieGenre.GenreId equals genre.GenreId
                            where movieGenre.MovieId == item.movie.MovieId
                            select genre.GenreName
                        )
                    ),
                    ScreenWriter = string.Join(
                        ", ",
                        (
                            from movieScreenwriter in appDbContext.MovieScreenwriters
                            join screenwriter in appDbContext.Screenwriters
                                on movieScreenwriter.ScreenwriterId equals screenwriter.ScreenwriterId
                            where movieScreenwriter.MovieId == item.movie.MovieId
                            select screenwriter.ScreenwriterFullName
                        )
                    ),
                    Media = (
                        from media in appDbContext.Media
                        where media.MediaId == item.movie.MediaId
                        select new
                        {
                            media.MovieDescription,
                            media.MoviePhoto,
                            media.MovieTrailer
                        }
                    ).ToList()
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
            var movieList = (
                from movie in appDbContext.Movies
                where movie.MovieId == id
                join movieDirector in appDbContext.MovieDirectors
                    on movie.MovieId equals movieDirector.MovieId
                join director in appDbContext.Directors
                    on movieDirector.DirectorId equals director.DirectorId
                join movieGenre in appDbContext.MovieGenres
                    on movie.MovieId equals movieGenre.MovieId
                join genre in appDbContext.Genres on movieGenre.GenreId equals genre.GenreId
                join MovieScreenwriter in appDbContext.MovieScreenwriters
                    on movie.MovieId equals MovieScreenwriter.MovieId
                join Screenwriter in appDbContext.Screenwriters
                    on MovieScreenwriter.ScreenwriterId equals Screenwriter.ScreenwriterId
                join Media in appDbContext.Media on movie.MediaId equals Media.MediaId
                select new { movie }
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

                    Director = string.Join(
                        ", ",
                        (
                            from movieDirector in appDbContext.MovieDirectors
                            join director in appDbContext.Directors
                                on movieDirector.DirectorId equals director.DirectorId
                            where movieDirector.MovieId == item.movie.MovieId
                            select director.DirectorFullName
                        )
                    ),
                    Genre = string.Join(
                        ", ",
                        (
                            from movieGenre in appDbContext.MovieGenres
                            join genre in appDbContext.Genres
                                on movieGenre.GenreId equals genre.GenreId
                            where movieGenre.MovieId == item.movie.MovieId
                            select genre.GenreName
                        )
                    ),
                    ScreenWriter = string.Join(
                        ", ",
                        (
                            from movieScreenwriter in appDbContext.MovieScreenwriters
                            join screenwriter in appDbContext.Screenwriters
                                on movieScreenwriter.ScreenwriterId equals screenwriter.ScreenwriterId
                            where movieScreenwriter.MovieId == item.movie.MovieId
                            select screenwriter.ScreenwriterFullName
                        )
                    ),
                    Media = (
                        from media in appDbContext.Media
                        where media.MediaId == item.movie.MediaId
                        select new
                        {
                            media.MovieDescription,
                            media.MoviePhoto,
                            media.MovieTrailer
                        }
                    ).ToList()
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

        [HttpPost]
        public async Task<ActionResult<Movie>> onPostAsync([FromBody] MovieDTO movieDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Перевіряємо, чи існує фільм з такою ж назвою вже в базі даних
                    var existingMovie = await appDbContext.Movies.FirstOrDefaultAsync(m =>
                        m.MovieTitle == movieDto.MovieTitle
                    );
                    if (existingMovie != null)
                    {
                        return Conflict("A movie with this title already exists.");
                    }

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

                    appDbContext.Movies.Add(movie);
                    await appDbContext.SaveChangesAsync();
                    var createdMovie = await appDbContext.Movies.FindAsync(movie.MovieId);

                    return StatusCode(201, createdMovie);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }
            else
            {
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
