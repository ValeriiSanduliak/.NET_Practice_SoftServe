namespace CinemaAPI.DTOs
{
    public class MovieDTO
    {
        public string MovieTitle { get; set; } = null!;

        public TimeOnly Duration { get; set; }

        public string Country { get; set; } = null!;

        public DateOnly WorldPremiere { get; set; }

        public DateOnly UkrainePremiere { get; set; }

        public string Rating { get; set; } = null!;

        public DateOnly EndOfShow { get; set; }

        public string Limitations { get; set; } = null!;

        public int MediaId { get; set; }

        public List<ActorInfo> Actors { get; set; }
        public List<int> GenreId { get; set; }

        public List<int> DirectorId { get; set; }

        public List<int> ScreenwriterId { get; set; }
    }
}

public class ActorInfo
{
    public int ActorId { get; set; }
    public string ActorNickname { get; set; }
}
