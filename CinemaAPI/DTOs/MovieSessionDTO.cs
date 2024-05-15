namespace CinemaAPI.DTOs
{
    public class MovieSessionDTO
    {
        public int MovieSessionId { get; set; }
        public string MovieTitle { get; set; } = null!;
        public TimeOnly StartTime { get; set; }
    }

    public class MovieSessionPostDTO
    {
        public int MovieSessionId { get; set; }

        public int MovieId { get; set; }

        public TimeOnly? StartTime { get; set; }

        public int? TheLowestPrice { get; set; }

        public int? MiddlePrice { get; set; }

        public int? TheHighestPrice { get; set; }

        public int HallId { get; set; }
    }
}
