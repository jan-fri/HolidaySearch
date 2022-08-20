using HolidaySearch.Entities;

namespace HolidaySearch.Repositories
{
    public interface IHotelRepository
    {
        List<Hotel> GetHotelList();
        List<Hotel> SearchHotels(DateTime arrivalDate, string localAirport, int duration);
    }
}
