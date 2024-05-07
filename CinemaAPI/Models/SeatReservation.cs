using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class SeatReservation
{
    public int SeatReservationId { get; set; }

    public int HallId { get; set; }

    public int RowNumber { get; set; }

    public int SeatNumber { get; set; }

    public bool IsReserved { get; set; }

    public virtual Hall Hall { get; set; } = null!;

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();
}
