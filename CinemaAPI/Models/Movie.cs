﻿using System;
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

    public virtual Medium Media { get; set; } = null!;
}