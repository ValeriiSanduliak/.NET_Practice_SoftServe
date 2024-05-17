using System.ComponentModel.DataAnnotations;
using CinemaAPI.Models;

namespace CinemaAPI.DTOs
{
    public class MovieSessionDTO
    {
        public int MovieSessionId { get; set; }

        public TimeOnly? StartTime { get; set; }

        public int? TheLowestPrice { get; set; }

        public int? MiddlePrice { get; set; }

        public int? TheHighestPrice { get; set; }

        public virtual EntityWithHallList Hall { get; set; } = null!;

        public virtual EntityWithMovieList Movie { get; set; } = null!;

        public virtual ICollection<EntityWithReservation> Reservations { get; set; } =
            new List<EntityWithReservation>();
    }

    public class HallMovieSessionDTO
    {
        public int MovieSessionId { get; set; }
        public string MovieTitle { get; set; } = null!;
        public TimeOnly StartTime { get; set; }
    }

    public class MovieSessionPostDTO
    {
        [Required(ErrorMessage = "MovieId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "MovieId must be a positive number")]
        public int MovieId { get; set; }

        public TimeOnly? StartTime { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int? TheLowestPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int? MiddlePrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int? TheHighestPrice { get; set; }

        [Required(ErrorMessage = "HallId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int HallId { get; set; }
    }

    public class MovieSessionPatchDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "MovieId must be a positive number")]
        public int? MovieId { get; set; }

        public TimeOnly? StartTime { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int? TheLowestPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int? MiddlePrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int? TheHighestPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int? HallId { get; set; }
    }

    public class MovieSessionGetNewDTO
    {
        public int MovieSessionId { get; set; }

        public string MovieTitle { get; set; } = null!;

        public string HallName { get; set; } = null!;

        public string HallType { get; set; } = null!;

        public TimeOnly Duration { get; set; }

        public string Limitations { get; set; } = null!;

        public string Rating { get; set; } = null!;

        public TimeOnly? StartTime { get; set; }

        public int? TheLowestPrice { get; set; }

        public int? MiddlePrice { get; set; }

        public int? TheHighestPrice { get; set; }
    }
}
