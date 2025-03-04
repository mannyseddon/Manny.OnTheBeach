using Manny.OnTheBeach.Models.Data;

namespace Manny.OnTheBeach.Models.Mapper
{
    public static class FlightMapper
    {
        public static Flight Mapper(this FlightData data)
        {
            return new Flight
            {
                Airline = data.Airline,
                DepartureDate = data.DepartureDate,
                From = data.From,
                Id = data.Id,
                Price = data.Price,
                To = data.To
            };
        }
    }
}