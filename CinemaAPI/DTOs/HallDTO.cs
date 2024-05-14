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
        public string HallName { get; set; } = null!;

        public string HallType { get; set; } = null!;

        public int NumberOfRows { get; set; }

        public int NumberOfSeats { get; set; }
    }

    public class HallPatchDTO
    {
        public string? HallName { get; set; } = null!;

        public string? HallType { get; set; } = null!;

        public int? NumberOfRows { get; set; }

        public int? NumberOfSeats { get; set; }
    }
}
