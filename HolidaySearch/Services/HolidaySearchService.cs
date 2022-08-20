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
            throw new NotImplementedException();
        }
    }
}
