using HolidaySearch.Entities;
using HolidaySearch.Repositories;

namespace HolidaySearch.Services
{
    public class HolidaySearchService : IHolidaySearchService
    {
        private IFlightRepository _flightRepository;
        private IHotelRepository _hotelRepository;

        public HolidaySearchService(IFlightRepository flightRepository, IHotelRepository hotelRepository)
        {
            _flightRepository = flightRepository;
            _hotelRepository = hotelRepository;
        }

        public List<HolidaySearchReslut> SearchHoliday(List<string> departingFrom, string travelingTo, DateTime departureDate, int duration)
        {
            var searchResults = new List<HolidaySearchReslut>();
            var flights = _flightRepository.SearchFlights(departureDate, departingFrom, travelingTo);
            var hotels = _hotelRepository.SearchHotels(departureDate, travelingTo, duration);

            if (hotels != null && hotels.Any() && flights != null && flights.Any())
            {
                hotels.ForEach(hotel => flights.ForEach(flight => searchResults.Add(new HolidaySearchReslut { Flight = flight, Hotel = hotel })));
            }

            return searchResults.ToList();
        }
    }
}
