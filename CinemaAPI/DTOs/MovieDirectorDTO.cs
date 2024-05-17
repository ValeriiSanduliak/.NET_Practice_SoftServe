namespace CinemaAPI.DTOs
{
    public class MovieDirectorDTO
    {
        public int MovieId { get; set; }

        public int DirectorId { get; set; }
    }

    public class MovieDirectorPatchDTO
    {
        public int? MovieId { get; set; }

        public int? DirectorId { get; set; }
    }
}
