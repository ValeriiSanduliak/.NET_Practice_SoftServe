namespace CinemaAPI.DTOs
{
    public class MediaDTO
    {
        public string MovieDescription { get; set; } = null!;

        public string MoviePhoto { get; set; } = null!;

        public string MovieTrailer { get; set; } = null!;
    }

    public class MediaGetDTO
    {
        public int MediaId { get; set; }

        public string MovieDescription { get; set; } = null!;

        public string MoviePhoto { get; set; } = null!;

        public string MovieTrailer { get; set; } = null!;
    }
}
