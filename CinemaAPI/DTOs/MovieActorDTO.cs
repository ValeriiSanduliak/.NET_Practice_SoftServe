namespace CinemaAPI.DTOs
{
    public class MovieActorDTO
    {
        public int ActorId { get; set; }

        public string ActorFullName { get; set; } = null!;

        public string? ActorPhoto { get; set; }
    }
}
