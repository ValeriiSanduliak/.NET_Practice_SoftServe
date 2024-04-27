using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Hall
{
    public int HallId { get; set; }

    public string HallName { get; set; } = null!;

    public string HallType { get; set; } = null!;
}
