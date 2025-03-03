using System.Text.Json.Serialization;

namespace Manny.OnTheBeach.Models.Data
{
    public class Hotel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("arrival_date")]
        public string ArrivalDateString { get; set; } = string.Empty;

        [JsonIgnore]
        public DateOnly ArrivalDate => DateOnly.Parse(ArrivalDateString);

        [JsonPropertyName("price_per_night")]
        public int PricePerNight { get; set; }

        [JsonPropertyName("local_airports")]
        public List<string> LocalAirports { get; set; } = new List<string>();

        [JsonPropertyName("nights")]
        public int Nights { get; set; }

        [JsonIgnore]
        public int PriceAllNights => PricePerNight * Nights;
    }
}