using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Actor
{
    public int ActorId { get; set; }

    public string ActorFullName { get; set; } = null!;

    public byte[] ActorPhoto { get; set; } = null!;

    public DateOnly? ActorBirthday { get; set; }

    public string? ActorCountry { get; set; }

    public int? ActorHeight { get; set; }
}
