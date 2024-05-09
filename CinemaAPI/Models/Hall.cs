using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaAPI.Models;

public partial class Hall
{
    public int HallId { get; set; }

    public string HallName { get; set; } = null!;

    public string HallType { get; set; } = null!;

    public int NumberOfRows { get; set; }

    public int NumberOfSeats { get; set; }

    //public List<int> SeatReservationIds { get; set; } = new List<int>();

    [JsonIgnore]
    public virtual ICollection<SeatReservation> SeatReservations { get; set; } =
        new List<SeatReservation>();
}
