using System.ComponentModel.DataAnnotations;
using CinemaAPI.Models;

namespace CinemaAPI.DTOs
{
    public class SeatReservationDTO
    {
        public int SeatReservationId { get; set; }

        public int HallId { get; set; }

        public int RowNumber { get; set; }

        public int SeatNumber { get; set; }

        public bool IsReserved { get; set; }
    }

    public class SeatReservationPostDTO
    {
        [Required(ErrorMessage = "HallId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int HallId { get; set; }

        [Required(ErrorMessage = "RowNumber is required")]
        [Range(1, int.MaxValue, ErrorMessage = "RowNumber must be a positive number")]
        public int RowNumber { get; set; }

        [Required(ErrorMessage = "SeatNumber is required")]
        [Range(1, int.MaxValue, ErrorMessage = "SeatNumber must be a positive number")]
        public int SeatNumber { get; set; }
    }

    public class SeatReservationPatchDTO
    {
        [Required(ErrorMessage = "IsReserved is required")]
        public bool IsReserved { get; set; }
    }
}
