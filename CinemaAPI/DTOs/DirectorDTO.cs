using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.DTOs
{
    public class DirectorDTO
    {
        public int DirectorId { get; set; }

        public string DirectorFullName { get; set; } = null!;

        public List<EntityWithMovieList> Movies { get; set; } = new List<EntityWithMovieList>();
    }

    public class DirectorPostDTO
    {
        [Required(ErrorMessage = "DirectorFullName is required")]
        public string DirectorFullName { get; set; } = null!;
    }

    public class DirectorMovieDTO
    {
        public int DirectorId { get; set; }

        public string DirectorFullName { get; set; } = null!;
    }
}
