namespace Manny.OnTheBeach.Models;

public class HolidayRequirements
{
    public List<string> DepartingFrom { get; set; } = new List<string>();
    public string TravelingTo { get; set; } = string.Empty;
    public DateOnly DepartureDate { get; set; } = DateOnly.MinValue;
    public int Duration { get; set; }
}