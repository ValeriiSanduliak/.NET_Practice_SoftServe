namespace CinemaAPI.DTOs
{
    public class MovieActorDTO
    {
        public int ActorId { get; set; }

        public string ActorFullName { get; set; } = null!;

        public string? ActorPhoto { get; set; }
    }

    public class MovieActorPostDTO
    {
        public int ActorId { get; set; }

        public int MovieId { get; set; }

        public string ActorNickname { get; set; }
    }
}
