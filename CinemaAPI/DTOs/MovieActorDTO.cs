namespace CinemaAPI.DTOs
{
    public class MovieActorListDTO
    {
        public int MovieId { get; set; }

        public string MovieTitle { get; set; }

        public string RoleName { get; set; }
      
    public class MovieActorDTO
    {
        public int ActorId { get; set; }

        public string ActorFullName { get; set; } = null!;

        public string? ActorPhoto { get; set; }
    }
}
