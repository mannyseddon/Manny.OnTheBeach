using Manny.OnTheBeach.Models.Data;

namespace Manny.OnTheBeach.Models.Mapper
{
    public static class HotelMapper
    {
        public static Hotel Mapper(this HotelData data)
        {
            return new Hotel
            {
                ArrivalDate = data.ArrivalDate,
                Id = data.Id,
                LocalAirports = data.LocalAirports,
                Name = data.Name,
                Nights = data.Nights,
                PriceAllNights = data.PriceAllNights,
                PricePerNight = data.PricePerNight
            };
        }
    }
}