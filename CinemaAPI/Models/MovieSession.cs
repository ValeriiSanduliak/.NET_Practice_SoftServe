using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class MovieSession
{
    public int MovieSessionId { get; set; }

    public string MovieTitle { get; set; } = null!;

    public TimeOnly? StartTime { get; set; }

    public int? TheLowestPrice { get; set; }

    public int? MiddlePrice { get; set; }

    public int? TheHighestPrice { get; set; }

    public string HallName { get; set; } = null!;

    public string HallType { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
