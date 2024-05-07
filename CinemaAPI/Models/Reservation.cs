using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int UserId { get; set; }

    public int MovieSessionId { get; set; }

    public int PriceId { get; set; }

    public int Discount { get; set; }

    public virtual MovieSession MovieSession { get; set; } = null!;

    public virtual Price Price { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
