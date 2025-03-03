namespace Manny.OnTheBeach.Models;

public class HolidayRequirements
{
    public string DepartingFrom { get; set; } = string.Empty;
    public string TravelingTo { get; set; } = string.Empty;
    public DateOnly DepartureDate { get; set; } = DateOnly.MinValue;
    public int Duration { get; set; }
}