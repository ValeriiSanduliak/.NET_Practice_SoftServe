using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string MovieTitle { get; set; } = null!;

    public int MediaId { get; set; }

    public TimeOnly Duration { get; set; }

    public string Country { get; set; } = null!;

    public DateOnly WorldPremiere { get; set; }

    public DateOnly UkrainePremiere { get; set; }

    public string Rating { get; set; } = null!;

    public DateOnly EndOfShow { get; set; }

    public string Limitations { get; set; } = null!;

    public virtual Media Media { get; set; } = null!;

    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();

    public virtual ICollection<MovieDirector> MovieDirectors { get; set; } =
        new List<MovieDirector>();

    public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    public virtual ICollection<MovieScreenwriter> MovieScreenwriters { get; set; } =
        new List<MovieScreenwriter>();

    public virtual ICollection<MovieSession> MovieSessions { get; set; } = new List<MovieSession>();

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();
}
