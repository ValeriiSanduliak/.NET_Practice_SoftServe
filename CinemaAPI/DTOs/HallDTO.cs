using System.ComponentModel.DataAnnotations;
using CinemaAPI.Models;

namespace CinemaAPI.DTOs
{
    public class HallDTO
    {
        public int HallId { get; set; }
        public string HallName { get; set; } = null!;

        public string HallType { get; set; } = null!;

        public int NumberOfRows { get; set; }

        public int NumberOfSeats { get; set; }

        public virtual ICollection<MovieSessionDTO> MovieSessions { get; set; } =
            new List<MovieSessionDTO>();
    }

    public class HallPostDTO
    {
        [Required(ErrorMessage = "HallName is required")]
        public string HallName { get; set; } = null!;

        [Required(ErrorMessage = "HallType is required")]
        public string HallType { get; set; } = null!;

        [Required(ErrorMessage = "NumberOfRows is required")]
        [Range(0, int.MaxValue, ErrorMessage = "NumberOfRows must be a positive number")]
        public int NumberOfRows { get; set; }

        [Required(ErrorMessage = "NumberOfSeats is required")]
        [Range(0, int.MaxValue, ErrorMessage = "NumberOfSeats must be a positive number")]
        public int NumberOfSeats { get; set; }
    }

    public class HallPatchDTO
    {
        public string? HallName { get; set; } = null!;

        public string? HallType { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "NumberOfRows must be a positive number")]
        public int? NumberOfRows { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "NumberOfSeats must be a positive number")]
        public int? NumberOfSeats { get; set; }
    }
}
