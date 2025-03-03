using Manny.OnTheBeach.FileReader;
using Manny.OnTheBeach.Models;
using Manny.OnTheBeach.Models.Data;

namespace Manny.OnTheBeach.Search
{
    public static class SearchHolidaysExtensions
    {
        private const string FlightsFilePath = "flights.json";
        private const string HotelsFilePath = "hotels.json";
        private const string LocalFilePath = @"..\..\..\..\";

        public static async Task<List<HolidaySearchResults>> SearchHolidaysAsync(this HolidayRequirements holidayRequirements)
        {
            var flightsData = Path.Combine(LocalFilePath, FlightsFilePath);
            var hotelsData = Path.Combine(LocalFilePath, HotelsFilePath);

            var flights = await flightsData.GetDataFromFileAsync<Flight>();
            var hotels = await hotelsData.GetDataFromFileAsync<Hotel>();

            var results = new List<HolidaySearchResults>
            {
                new HolidaySearchResults()
            };




            return results;
        }
    }
}
