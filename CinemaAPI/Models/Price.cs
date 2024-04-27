using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Price
{
    public int MovieId { get; set; }

    public int HallId { get; set; }

    public int RowNumber { get; set; }

    public int SeatNumber { get; set; }

    public string DayOfTheWeek { get; set; } = null!;

    public TimeOnly TimeOfDay { get; set; }

    public string? Benefits { get; set; }

    public int Price1 { get; set; }

    public virtual Hall Hall { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
