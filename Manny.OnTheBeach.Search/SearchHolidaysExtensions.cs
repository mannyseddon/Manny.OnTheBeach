using Manny.OnTheBeach.FileReader;
using Manny.OnTheBeach.Models;
using Manny.OnTheBeach.Models.Data;
using Manny.OnTheBeach.Models.Mapper;

namespace Manny.OnTheBeach.Search
{
    public static class SearchHolidaysExtensions
    {
        private const string FlightsFilePath = "flights.json";
        private const string HotelsFilePath = "hotels.json";
        private const string LocalFilePath = @"..\..\..\..\";

        public static async Task<List<HolidaySearchResults>> SearchHolidaysAsync(this HolidayRequirements requirements)
        {
            var flightsData = Path.Combine(LocalFilePath, FlightsFilePath);
            var hotelsData = Path.Combine(LocalFilePath, HotelsFilePath);

            var flights = await flightsData.GetDataFromFileAsync<FlightData>();
            var hotels = await hotelsData.GetDataFromFileAsync<HotelData>();

            var matchingFlights = flights.GetMatchingFlights(requirements);
            var matchingHotels = hotels.GetMatchingHotels(requirements);

            var results = GetHolidaySearchResults(matchingFlights, matchingHotels);

            return results;
        }

        private static List<FlightData> GetMatchingFlights(this List<FlightData> flights, HolidayRequirements requirements)
        {
            var matchingFlights = flights.Where(flight => flight.DepartureDate == requirements.DepartureDate && (!requirements.DepartingFrom.Any() || (requirements.DepartingFrom.Any() && requirements.DepartingFrom.Contains(flight.From))) && flight.To == requirements.TravelingTo).ToList();

            return matchingFlights;
        }

        private static List<HotelData> GetMatchingHotels(this List<HotelData> hotels, HolidayRequirements requirements)
        {
            var matchingHotels = hotels.Where(hotel => hotel.ArrivalDate == requirements.DepartureDate && hotel.LocalAirports.Contains(requirements.TravelingTo) && hotel.Nights == requirements.Duration).ToList();
            return matchingHotels;
        }

        private static List<HolidaySearchResults> GetHolidaySearchResults(List<FlightData> matchingFlights, List<HotelData> matchingHotels)
        {
            var results = matchingFlights
                .SelectMany(flight => matchingHotels, (flight, hotel) => new HolidaySearchResults
                {
                    Flight = flight.Mapper(),
                    Hotel = hotel.Mapper()
                    //Total calculated by model
                })
                .OrderBy(result => result.TotalPrice)
                .ToList();

            return results;
        }
    }
}