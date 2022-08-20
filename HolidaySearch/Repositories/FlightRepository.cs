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

        public List<Flight> SearchFlights(DateTime departureDate, List<string> departingFrom, string travelingTo)
        {
            List<Flight> matchingFlights = new List<Flight>();
            var allFlights = GetFlightList();
            var selectedFlights = allFlights.Where(x => x.DepartureDate >= departureDate && x.TravalingTo == travelingTo);

            if (selectedFlights != null && selectedFlights.Any())
            {
                if (!departingFrom.Any())
                {
                    matchingFlights.AddRange(selectedFlights);
                }

                foreach (var airport in departingFrom)
                {
                    var matchingAirports = selectedFlights.Where(x => x.DepartingFrom == airport);
                    matchingFlights.AddRange(matchingAirports);  
                }

                matchingFlights = matchingFlights.OrderBy(x => x.DepartureDate).ToList();
            }

            return matchingFlights;
        }
    }
}
