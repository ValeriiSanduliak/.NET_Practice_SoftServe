using System.ComponentModel.DataAnnotations;
using CinemaAPI.Models;

namespace CinemaAPI.DTOs
{
    public class PriceDTO
    {
        public int PriceId { get; set; }

        public int Price1 { get; set; }

        public virtual EntityWithMovieList Movie { get; set; } = null!;

        public virtual SeatReservationDTO SeatReservation { get; set; } = null!;
    }

    public class PricePostDTO
    {
        [Required(ErrorMessage = "MovieId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "MovieId must be a positive number")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "SeatReservationId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "SeatReservationId must be a positive number")]
        public int SeatReservationId { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int Price { get; set; }
    }

    public class PricePatchDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "MovieId must be a positive number")]
        public int? MovieId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "SeatReservationId must be a positive number")]
        public int? SeatReservationId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int? Price { get; set; }
    }
}
