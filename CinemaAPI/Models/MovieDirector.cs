using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class MovieDirector
{
    public int MovieId { get; set; }

    public int DirectorId { get; set; }

    public virtual Director Director { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
