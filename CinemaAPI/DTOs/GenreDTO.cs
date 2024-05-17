using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.DTOs
{
    public class GenreDTO
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; } = null!;
    }

    public class GenrePostDTO
    {
        [Required(ErrorMessage = "GenreName is required")]
        public string GenreName { get; set; } = null!;
    }
}
