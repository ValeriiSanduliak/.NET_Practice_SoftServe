using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Director
{
    public int DirectorId { get; set; }

    public string DirectorFullName { get; set; } = null!;
}
