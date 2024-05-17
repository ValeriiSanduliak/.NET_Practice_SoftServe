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
}
