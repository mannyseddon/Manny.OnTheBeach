using System.Text.Json.Serialization;

namespace Manny.OnTheBeach.Models.Data
{
    public class FlightData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("airline")]
        public string Airline { get; set; } = string.Empty;

        [JsonPropertyName("from")]
        public string From { get; set; } = string.Empty;

        [JsonPropertyName("to")]
        public string To { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("departure_date")]
        public string DepartureDateString { get; set; } = string.Empty;

        [JsonIgnore]
        public DateOnly DepartureDate => DateOnly.Parse(DepartureDateString);
    }
}