using HolidaySearch.Entities;
using HolidaySearch.Helpers;
using System.Text.Json;

namespace HolidaySearch.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IRepositoryHelper _repositoryHelper;
        public FlightRepository(IRepositoryHelper repositoryHelper)
        {
            _repositoryHelper = repositoryHelper;
        }

        public List<Flight> GetFlightList()
        {
            var flightListSource = _repositoryHelper.ReadFileContent("flights.json");
            return JsonSerializer.Deserialize<List<Flight>>(flightListSource, _repositoryHelper.SetJsonSerializerOptions());
        }

        public List<Flight> SearchFlights(DateTime departureDate, string departingFrom, string travelingTo)
        {
            throw new NotImplementedException();
        }
    }
}
