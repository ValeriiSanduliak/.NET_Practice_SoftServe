using CinemaAPI.Models;

namespace CinemaAPI.DTOs
{
    public class MovieActorList
    {
        public int MovieId { get; set; }

        public string MovieTitle { get; set; }

        public string RoleName { get; set; }
    }

    public class EntityWithMovieList
    {
        public int MovieId { get; set; }

        public string MovieTitle { get; set; }
    }

    public class EntityWithHallList
    {
        public int HallId { get; set; }
        public string HallName { get; set; } = null!;

        public string HallType { get; set; } = null!;

        public int NumberOfRows { get; set; }

        public int NumberOfSeats { get; set; }
    }

    public class EntityWithReservation
    {
        public int ReservationId { get; set; }

        public int UserId { get; set; }

        public int MovieSessionId { get; set; }

        public int PriceId { get; set; }
    }
}
