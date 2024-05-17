using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.DTOs
{
    public class ScreenwriterDTO
    {
        public int ScreenwriterId { get; set; }

        public string ScreenwriterFullName { get; set; } = null!;
    }

    public class ScreenWriterWithMoviesDTO
    {
        public int ScreenwriterId { get; set; }

        public string ScreenwriterFullName { get; set; } = null!;

        public List<EntityWithMovieList> Movies { get; set; } = new List<EntityWithMovieList>();
    }

    public class ScreenwriterPostDTO
    {
        [Required(ErrorMessage = "ScreenwriterFullName is required")]
        public string ScreenwriterFullName { get; set; } = null!;
    }
}
