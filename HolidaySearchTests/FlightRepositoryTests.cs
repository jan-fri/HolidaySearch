using HolidaySearch.Helpers;
using HolidaySearch.Repositories;

namespace HolidaySearchTests
{
    public class FlightRepositoryTests
    {
        [Fact]
        public void DeserializeFlightsJson_CheckMappings()
        {
            //Arrange
            var flightRepo = new FlightRepository(repoHelperMock);

            //Act
            var allFlights = flightRepo.GetFlightList();

            //Assert
            Assert.True(allFlights.All(x => x.Id.GetType() == typeof(int)));
            Assert.True(allFlights.All(x => !string.IsNullOrEmpty(x.Airline)));
            Assert.True(allFlights.All(x => !string.IsNullOrEmpty(x.From)));
            Assert.True(allFlights.All(x => !string.IsNullOrEmpty(x.To)));
            Assert.True(allFlights.All(x => x.Price.GetType() == typeof(decimal)));
            Assert.True(allFlights.All(x => x.DepartureDate.GetType() == typeof(DateOnly)));
        }
    }
}