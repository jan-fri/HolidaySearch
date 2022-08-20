using HolidaySearch.Helpers;
using HolidaySearch.Repositories;

namespace HolidaySearchTests
{
    public class FlightRepositoryTests
    {
        [Fact]
        public void DeserializeFlightsJson_VerifyMappings()
        {
            //Arrange
            var repoHelper = new RepositoryHelper();
            var flightRepo = new FlightRepository(repoHelper);

            //Act
            var allFlights = flightRepo.GetFlightList();

            //Assert
            Assert.True(allFlights.All(x => x.Id.GetType() == typeof(int)));
            Assert.True(allFlights.All(x => !string.IsNullOrEmpty(x.Airline)));
            Assert.True(allFlights.All(x => !string.IsNullOrEmpty(x.DepartingFrom)));
            Assert.True(allFlights.All(x => !string.IsNullOrEmpty(x.TravalingTo)));
            Assert.True(allFlights.All(x => x.Price.GetType() == typeof(decimal)));
            Assert.True(allFlights.All(x => x.DepartureDate.GetType() == typeof(DateTime)));
        }

        [Fact]
        public void SearchFlights_ReturnListOfFlightsMatchingCriteria()
        {
            //Arrange
            var repoHelper = new RepositoryHelper();
            var flightRepo = new FlightRepository(repoHelper);
            var departureDate = new DateTime(2023, 07, 01);
            var departingFrom = "MAN";
            var travelingTo = "AGP";

            //Act
            var results = flightRepo.SearchFlights(departureDate, departingFrom, travelingTo);

            //Assert
            Assert.NotNull(results);
            Assert.True(results.All(x => x.DepartingFrom == departingFrom));
            Assert.True(results.All(x => x.TravalingTo == travelingTo));
            Assert.True(results.All(x => x.DepartureDate >= departureDate));
        }

    }
}