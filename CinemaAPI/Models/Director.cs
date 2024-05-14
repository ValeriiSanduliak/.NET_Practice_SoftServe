using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Director
{
    public int DirectorId { get; set; }

    public string DirectorFullName { get; set; } = null!;

    public virtual ICollection<MovieDirector> MovieDirectors { get; set; } = new List<MovieDirector>();
}
