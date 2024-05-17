using System.ComponentModel.DataAnnotations;
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

        public List<MovieActorList> Movies { get; set; } = new List<MovieActorList>();
    }

    public class ActorPostDTO
    {
        [Required(ErrorMessage = "ActorFullName is required")]
        public string ActorFullName { get; set; }
        public string? ActorPhoto { get; set; }
        public DateOnly? ActorBirthday { get; set; }
        public string? ActorCountry { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "ActorHeight must be a positive number")]
        public int? ActorHeight { get; set; }
    }

    public class ActorPatchDTO
    {
        public string? ActorFullName { get; set; }
        public string? ActorPhoto { get; set; }
        public DateOnly? ActorBirthday { get; set; }
        public string? ActorCountry { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "ActorHeight must be a positive number")]
        public int? ActorHeight { get; set; }
    }
}
