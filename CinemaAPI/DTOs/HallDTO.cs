namespace CinemaAPI.DTOs
{
    public class HallDTO
    {
        public string HallName { get; set; } = null!;

        public string HallType { get; set; } = null!;

        public int NumberOfRows { get; set; }

        public int NumberOfSeats { get; set; }
    }
}
