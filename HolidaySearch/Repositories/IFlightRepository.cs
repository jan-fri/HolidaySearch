using HolidaySearch.Entities;

namespace HolidaySearch.Repositories
{
    public interface IFlightRepository
    {
        List<Flight> GetFlightList();
        List<Flight> SearchFlights(DateTime departureDate, string departingFrom, string travelingTo);
    }
}
