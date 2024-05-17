using System;
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
                .Movies.Include(m => m.MovieActors)
                .ThenInclude(m => m.Actor)
                .Include(m => m.MovieDirectors)
                .ThenInclude(m => m.Director)
                .Include(m => m.MovieGenres)
                .ThenInclude(m => m.Genre)
                .Include(m => m.MovieScreenwriters)
                .ThenInclude(m => m.Screenwriter)
                .Include(m => m.Media)
                .ToListAsync();

            if (movies == null)
            {
                return NotFound();
            }

            var returnMovies = movies
                .Select(movie => new MovieInfoDTO
                {
                    MovieId = movie.MovieId,
                    MovieTitle = movie.MovieTitle,
                    Duration = movie.Duration,
                    Country = movie.Country,
                    WorldPremiere = movie.WorldPremiere,
                    UkrainePremiere = movie.UkrainePremiere,
                    Rating = movie.Rating,
                    EndOfShow = movie.EndOfShow,
                    Limitations = movie.Limitations,
                    Actors = movie
                        .MovieActors.Select(ma => new MovieActorDTO
                        {
                            ActorId = ma.ActorId,
                            ActorFullName = ma.Actor.ActorFullName,
                            ActorPhoto = ma.Actor.ActorPhoto
                        })
                        .ToList(),
                    Directors = movie
                        .MovieDirectors.Select(md => new DirectorMovieDTO
                        {
                            DirectorId = md.DirectorId,
                            DirectorFullName = md.Director.DirectorFullName
                        })
                        .ToList(),
                    Media = new MediaGetDTO
                    {
                        MediaId = movie.Media.MediaId,
                        MovieDescription = movie.Media.MovieDescription,
                        MoviePhoto = movie.Media.MoviePhoto,
                        MovieTrailer = movie.Media.MovieTrailer
                    },
                    Genres = movie
                        .MovieGenres.Select(mg => new GenreDTO
                        {
                            GenreId = mg.GenreId,
                            GenreName = mg.Genre.GenreName
                        })
                        .ToList(),
                    Screenwriters = movie
                        .MovieScreenwriters.Select(ms => new ScreenwriterDTO
                        {
                            ScreenwriterId = ms.ScreenwriterId,
                            ScreenwriterFullName = ms.Screenwriter.ScreenwriterFullName
                        })
                        .ToList()
                })
                .ToList();

            if (!returnMovies.Any())
            {
                return NotFound();
            }

            return Ok(returnMovies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Movie>>> onGetMovieAsync(int id)
        {
            var movie = await appDbContext
                .Movies.Include(m => m.MovieActors)
                .ThenInclude(m => m.Actor)
                .Include(m => m.MovieDirectors)
                .ThenInclude(m => m.Director)
                .Include(m => m.MovieGenres)
                .ThenInclude(m => m.Genre)
                .Include(m => m.MovieScreenwriters)
                .ThenInclude(m => m.Screenwriter)
                .Include(m => m.Media)
                .FirstOrDefaultAsync(mid => mid.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            var returnMovie = new MovieInfoDTO
            {
                MovieId = movie.MovieId,
                MovieTitle = movie.MovieTitle,
                Duration = movie.Duration,
                Country = movie.Country,
                WorldPremiere = movie.WorldPremiere,
                UkrainePremiere = movie.UkrainePremiere,
                Rating = movie.Rating,
                EndOfShow = movie.EndOfShow,
                Limitations = movie.Limitations,
                Actors = movie
                    .MovieActors.Select(ma => new MovieActorDTO
                    {
                        ActorId = ma.ActorId,
                        ActorFullName = ma.Actor.ActorFullName,
                        ActorPhoto = ma.Actor.ActorPhoto
                    })
                    .ToList(),
                Directors = movie
                    .MovieDirectors.Select(md => new DirectorMovieDTO
                    {
                        DirectorId = md.DirectorId,
                        DirectorFullName = md.Director.DirectorFullName
                    })
                    .ToList(),
                Media = new MediaGetDTO
                {
                    MediaId = movie.Media.MediaId,
                    MovieDescription = movie.Media.MovieDescription,
                    MoviePhoto = movie.Media.MoviePhoto,
                    MovieTrailer = movie.Media.MovieTrailer
                },
                Genres = movie
                    .MovieGenres.Select(mg => new GenreDTO
                    {
                        GenreId = mg.GenreId,
                        GenreName = mg.Genre.GenreName
                    })
                    .ToList(),
                Screenwriters = movie
                    .MovieScreenwriters.Select(ms => new ScreenwriterDTO
                    {
                        ScreenwriterId = ms.ScreenwriterId,
                        ScreenwriterFullName = ms.Screenwriter.ScreenwriterFullName
                    })
                    .ToList()
            };

            if (returnMovie == null)
            {
                return NotFound();
            }
            return Ok(returnMovie);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> onPostAsync([FromBody] MovieDTO movieDto)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<ActionResult<Movie>> OnPatchAsync(int id, [FromBody] MoviePatchDTO movie)
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
                    existingMovie.MovieTitle = movie.MovieTitle;
                }

                // Update other fields if provided
                if (movie.Duration.HasValue)
                {
                    existingMovie.Duration = movie.Duration.Value;
                }
                if (movie.Country != null)
                {
                    existingMovie.Country = movie.Country;
                }
                if (movie.WorldPremiere.HasValue)
                {
                    existingMovie.WorldPremiere = movie.WorldPremiere.Value;
                }
                if (movie.UkrainePremiere.HasValue)
                {
                    existingMovie.UkrainePremiere = movie.UkrainePremiere.Value;
                }
                if (movie.Rating != null)
                {
                    existingMovie.Rating = movie.Rating;
                }
                if (movie.EndOfShow.HasValue)
                {
                    existingMovie.EndOfShow = movie.EndOfShow.Value;
                }
                if (movie.Limitations != null)
                {
                    existingMovie.Limitations = movie.Limitations;
                }
                if (movie.MediaId.HasValue)
                {
                    existingMovie.MediaId = movie.MediaId.Value;
                }

                // Update actors, directors, genres, and screenwriters
                if (movie.Actors != null)
                {
                    // Update or add actors
                    foreach (var actorInfo in movie.Actors)
                    {
                        var existingMovieActor = await appDbContext.MovieActors.FirstOrDefaultAsync(
                            ma => ma.MovieId == id && ma.ActorId == actorInfo.ActorId
                        );

                        if (existingMovieActor != null)
                        {
                            existingMovieActor.ActorNickname = actorInfo.ActorNickname;
                        }
                        else
                        {
                            var newMovieActor = new MovieActor
                            {
                                MovieId = id,
                                ActorId = actorInfo.ActorId,
                                ActorNickname = actorInfo.ActorNickname
                            };
                            appDbContext.MovieActors.Add(newMovieActor);
                        }
                    }
                }

                // Update or add directors
                if (movie.DirectorId != null)
                {
                    foreach (var directorId in movie.DirectorId)
                    {
                        var existingMovieDirector =
                            await appDbContext.MovieDirectors.FirstOrDefaultAsync(md =>
                                md.MovieId == id && md.DirectorId == directorId
                            );

                        if (existingMovieDirector == null)
                        {
                            var newMovieDirector = new MovieDirector
                            {
                                MovieId = id,
                                DirectorId = directorId
                            };
                            appDbContext.MovieDirectors.Add(newMovieDirector);
                        }
                    }
                }

                // Update or add genres
                if (movie.GenreId != null)
                {
                    foreach (var genreId in movie.GenreId)
                    {
                        var existingMovieGenre = await appDbContext.MovieGenres.FirstOrDefaultAsync(
                            mg => mg.MovieId == id && mg.GenreId == genreId
                        );

                        if (existingMovieGenre == null)
                        {
                            var newMovieGenre = new MovieGenre { MovieId = id, GenreId = genreId };
                            appDbContext.MovieGenres.Add(newMovieGenre);
                        }
                    }
                }

                // Update or add screenwriters
                if (movie.ScreenwriterId != null)
                {
                    foreach (var screenwriterId in movie.ScreenwriterId)
                    {
                        var existingMovieScreenwriter =
                            await appDbContext.MovieScreenwriters.FirstOrDefaultAsync(ms =>
                                ms.MovieId == id && ms.ScreenwriterId == screenwriterId
                            );

                        if (existingMovieScreenwriter == null)
                        {
                            var newMovieScreenwriter = new MovieScreenwriter
                            {
                                MovieId = id,
                                ScreenwriterId = screenwriterId
                            };
                            appDbContext.MovieScreenwriters.Add(newMovieScreenwriter);
                        }
                    }
                }

                await appDbContext.SaveChangesAsync();

                return StatusCode(200);
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
            var movie = await appDbContext
                .Movies.Include(m => m.MovieActors)
                .ThenInclude(m => m.Actor)
                .Include(m => m.MovieDirectors)
                .ThenInclude(m => m.Director)
                .Include(m => m.MovieGenres)
                .ThenInclude(m => m.Genre)
                .Include(m => m.MovieScreenwriters)
                .ThenInclude(m => m.Screenwriter)
                .Include(m => m.Media)
                .Include(m => m.Prices)
                .Include(m => m.MovieSessions)
                .FirstOrDefaultAsync(mid => mid.MovieId == id);
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
