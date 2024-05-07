using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Medium
{
    public int MediaId { get; set; }

    public string MovieDescription { get; set; } = null!;

    public string MoviePhoto { get; set; } = null!;

    public string MovieTrailer { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
