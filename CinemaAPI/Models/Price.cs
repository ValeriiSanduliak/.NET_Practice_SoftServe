using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Price
{
    public int PriceId { get; set; }

    public int HallId { get; set; }

    public int Price1 { get; set; }

    public TimeOnly TimeOfDay { get; set; }

    public virtual Hall Hall { get; set; } = null!;
}
