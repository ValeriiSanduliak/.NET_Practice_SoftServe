using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaAPI.Models;

public partial class Media
{
    public int MediaId { get; set; }

    public string MovieDescription { get; set; } = null!;

    public string MoviePhoto { get; set; } = null!;

    public string MovieTrailer { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
