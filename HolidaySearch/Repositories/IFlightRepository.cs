using HolidaySearch.Entities;

namespace HolidaySearch.Repositories
{
    public interface IFlightRepository
    {
        List<Flight> GetFlightList();
    }
}
