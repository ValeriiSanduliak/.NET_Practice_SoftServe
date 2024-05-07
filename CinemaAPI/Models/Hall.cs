using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Hall
{
    public int HallId { get; set; }

    public string HallName { get; set; } = null!;

    public string HallType { get; set; } = null!;

    public int NumberOfRows { get; set; }

    public int NumberOfSeats { get; set; }

    public virtual ICollection<SeatReservation> SeatReservations { get; set; } = new List<SeatReservation>();
}
