using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Price
{
    public int PriceId { get; set; }

    public int MovieId { get; set; }

    public int SeatReservationId { get; set; }

    public int Price1 { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual SeatReservation SeatReservation { get; set; } = null!;
}
