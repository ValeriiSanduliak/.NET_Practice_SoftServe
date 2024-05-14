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

                foreach (var actorInfo in movieDto.Actors)
                {
                    var movieActor = new MovieActor
                    {
                        MovieId = movie.MovieId,
                        ActorId = actorInfo.ActorId,
                        ActorNickname = actorInfo.ActorNickname
                    };
                    appDbContext.MovieActors.Add(movieActor);
                }

                foreach (var directorId in movieDto.DirectorId)
                {
                    var movieDirector = new MovieDirector
                    {
                        MovieId = movie.MovieId,
                        DirectorId = directorId
                    };
                    appDbContext.MovieDirectors.Add(movieDirector);
                }

                foreach (var genreId in movieDto.GenreId)
                {
                    var movieGenre = new MovieGenre { MovieId = movie.MovieId, GenreId = genreId };
                    appDbContext.MovieGenres.Add(movieGenre);
                }

                foreach (var screenwriterId in movieDto.ScreenwriterId)
                {
                    var movieScreenwriter = new MovieScreenwriter
                    {
                        MovieId = movie.MovieId,
                        ScreenwriterId = screenwriterId
                    };
                    appDbContext.MovieScreenwriters.Add(movieScreenwriter);
                }

                await appDbContext.SaveChangesAsync();

                return StatusCode(201);
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

                // Check if the movie title has changed and if it has, check for uniqueness
                if (movie.MovieTitle != null && movie.MovieTitle != existingMovie.MovieTitle)
                {
                    var existingTitle = await appDbContext.Movies.FirstOrDefaultAsync(m =>
                        m.MovieTitle == movie.MovieTitle
                    );

                    if (existingTitle != null)
                    {
                        return BadRequest("The movie title already exists.");
                    }
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

                // Actors
                foreach (var actorInfo in movie.Actors)
                {
                    var existingMovieActor = await appDbContext.MovieActors.FirstOrDefaultAsync(
                        ma => ma.MovieId == id && ma.ActorId == actorInfo.ActorId
                    );

                    if (existingMovieActor != null)
                    {
                        // Update actor id
                        existingMovieActor.ActorId = actorInfo.ActorId;
                        existingMovieActor.ActorNickname = actorInfo.ActorNickname;
                        // Save changes to the database
                        await appDbContext.SaveChangesAsync();
                    }
                    else
                    {
                        // Add new actor to the movie
                        var newMovieActor = new MovieActor
                        {
                            MovieId = id,
                            ActorId = actorInfo.ActorId,
                            ActorNickname = actorInfo.ActorNickname
                        };
                        appDbContext.MovieActors.Add(newMovieActor);
                    }
                }

                // Update movie directors
                foreach (var directorId in movie.DirectorId)
                {
                    var existingMovieDirector =
                        await appDbContext.MovieDirectors.FirstOrDefaultAsync(md =>
                            md.MovieId == id && md.DirectorId == directorId
                        );

                    if (existingMovieDirector == null)
                    {
                        // Add new director to the movie
                        var newMovieDirector = new MovieDirector
                        {
                            MovieId = id,
                            DirectorId = directorId
                        };
                        appDbContext.MovieDirectors.Add(newMovieDirector);
                    }
                    else
                    {
                        // Update existing director
                        existingMovieDirector.MovieId = id;
                        existingMovieDirector.DirectorId = directorId;
                    }
                }

                // Update movie genres
                foreach (var genreId in movie.GenreId)
                {
                    var existingMovieGenre = await appDbContext.MovieGenres.FirstOrDefaultAsync(
                        mg => mg.MovieId == id && mg.GenreId == genreId
                    );

                    if (existingMovieGenre == null)
                    {
                        // Add new genre to the movie
                        var newMovieGenre = new MovieGenre { MovieId = id, GenreId = genreId };
                        appDbContext.MovieGenres.Add(newMovieGenre);
                    }
                    else
                    {
                        // Update existing genre
                        existingMovieGenre.MovieId = id;
                        existingMovieGenre.GenreId = genreId;
                    }
                }

                // Update movie screenwriters
                foreach (var screenwriterId in movie.ScreenwriterId)
                {
                    var existingMovieScreenwriter =
                        await appDbContext.MovieScreenwriters.FirstOrDefaultAsync(ms =>
                            ms.MovieId == id && ms.ScreenwriterId == screenwriterId
                        );

                    if (existingMovieScreenwriter == null)
                    {
                        // Add new screenwriter to the movie
                        var newMovieScreenwriter = new MovieScreenwriter
                        {
                            MovieId = id,
                            ScreenwriterId = screenwriterId
                        };
                        appDbContext.MovieScreenwriters.Add(newMovieScreenwriter);
                    }
                    else
                    {
                        // Update existing screenwriter
                        existingMovieScreenwriter.MovieId = id;
                        existingMovieScreenwriter.ScreenwriterId = screenwriterId;
                    }
                }

                await appDbContext.SaveChangesAsync();
                return StatusCode(201);
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
