using HolidaySearch.Entities;

namespace HolidaySearch.Services
{
    public interface IHolidaySearchService
    {
        List<HolidaySearchReslut> SearchHoliday(List<string> departingFrom, string travelingTo, DateTime departureDate, int duration);
    }
}
