using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class MoviePrice
{
    public int MovieId { get; set; }

    public int PriceId { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual Price Price { get; set; } = null!;
}
