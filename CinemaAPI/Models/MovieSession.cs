using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class MovieSession
{
    public int MovieSessionId { get; set; }

    public int MovieId { get; set; }

    public TimeOnly? StartTime { get; set; }

    public int? TheLowestPrice { get; set; }

    public int? MiddlePrice { get; set; }

    public int? TheHighestPrice { get; set; }

    public int HallId { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
