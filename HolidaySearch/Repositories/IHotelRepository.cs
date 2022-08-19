using HolidaySearch.Entities;

namespace HolidaySearch.Repositories
{
    public interface IHotelRepository
    {
        List<Hotel> GetHotelList();
    }
}
