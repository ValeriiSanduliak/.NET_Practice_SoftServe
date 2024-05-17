namespace CinemaAPI.DTOs
{
    public class MovieScreenwriterDTO
    {
        public int MovieId { get; set; }

        public int ScreenwriterId { get; set; }
    }

    public class MovieScreenwriterPatchDTO
    {
        public int? MovieId { get; set; }

        public int? ScreenwriterId { get; set; }
    }
}
