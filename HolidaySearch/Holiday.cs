using HolidaySearch.Entities;
using HolidaySearch.Services;

namespace HolidaySearch
{
    public class Holiday
    {
        private IHolidaySearchService _holidaySearchService;
        public Holiday(IHolidaySearchService holidaySearchService)
        {
            _holidaySearchService = holidaySearchService;
        }

        public List<HolidaySearchReslut> Search(List<string> departingFrom, string travelingTo, DateTime departureDate, int duration)
        {
            return _holidaySearchService.SearchHoliday(departingFrom, travelingTo, departureDate, duration);
        }
    }
}