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
