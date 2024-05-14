using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class MovieScreenwriter
{
    public int MovieId { get; set; }

    public int ScreenwriterId { get; set; }

    public int MovieScreenwriterId { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual Screenwriter Screenwriter { get; set; } = null!;
}
