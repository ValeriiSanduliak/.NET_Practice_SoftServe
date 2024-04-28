using System;
using System.Collections.Generic;

namespace CinemaAPI.Models;

public partial class Actor
{
    public string ActorFullName { get; set; } = null!;

    public byte[]? ActorPhoto { get; set; }

    public DateOnly? ActorBirthday { get; set; }

    public string? ActorCountry { get; set; }

    public int? ActorHeight { get; set; }

    public int ActorId { get; set; }
}
