namespace Manny.OnTheBeach.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateOnly ArrivalDate { get; set; } = DateOnly.MinValue;

        public int PricePerNight { get; set; }

        public int PriceAllNights { get; set; }

        public List<string> LocalAirports { get; set; } = new List<string>();

        public int Nights { get; set; }
    }
}