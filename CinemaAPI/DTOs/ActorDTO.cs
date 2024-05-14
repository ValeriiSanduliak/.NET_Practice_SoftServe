using CinemaAPI.Models;

namespace CinemaAPI.DTOs
{
    public class ActorDTO
    {
        public int ActorId { get; set; }
        public string ActorFullName { get; set; }
        public string? ActorPhoto { get; set; }
        public DateOnly? ActorBirthday { get; set; }
        public string? ActorCountry { get; set; }
        public int? ActorHeight { get; set; }

        //public List<MovieActorDTO> MovieActors { get; set; } = new List<MovieActorDTO>();
        public List<MovieActorListDTO> Movies { get; set; } = new List<MovieActorListDTO>();
    }
}
