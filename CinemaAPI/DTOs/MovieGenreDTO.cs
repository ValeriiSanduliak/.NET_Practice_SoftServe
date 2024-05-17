namespace CinemaAPI.DTOs
{
    public class MovieGenreDTO
    {
        public int MovieId { get; set; }

        public int GenreId { get; set; }
    }

    public class MovieGenrePatchDTO
    {
        public int? MovieId { get; set; }

        public int? GenreId { get; set; }
    }
}
