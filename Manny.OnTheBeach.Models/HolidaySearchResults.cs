namespace Manny.OnTheBeach.Models;

public class HolidaySearchResults
{
    public Flight Flight { get; set; } = new Flight();
    public Hotel Hotel { get; set; } = new Hotel();
    public int TotalPrice => Flight.Price + Hotel.PriceAllNights;
}