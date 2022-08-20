using HolidaySearch.Helpers;
using HolidaySearch.Repositories;
using Moq;

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
            var repoHelperMock = new Mock<IRepositoryHelper>();
            var flights = GenerateFlightJson();
            repoHelperMock.Setup(x => x.ReadFileContent(It.IsAny<string>())).Returns(flights);
            repoHelperMock.Setup(x => x.SetJsonSerializerOptions()).Returns(repoHelper.SetJsonSerializerOptions());
            var flightRepo = new FlightRepository(repoHelperMock.Object);
            var departureDate = new DateTime(2023, 07, 01);
            List<string> departingFrom = new List<string> { "MAN" };
            var travelingTo = "AGP";

            //Act
            var results = flightRepo.SearchFlights(departureDate, departingFrom, travelingTo);

            //Assert
            Assert.NotNull(results);
            Assert.Equal(3, results.Count);
            Assert.True(results.All(x => x.DepartingFrom == departingFrom[0]));
            Assert.True(results.All(x => x.TravalingTo == travelingTo));
            Assert.True(results.All(x => x.DepartureDate >= departureDate));
        }

        [Fact]
        public void SearchFlights_ReturnFlights_SortedByDepartureDate()
        {
            //Arrange
            var repoHelper = new RepositoryHelper();
            var repoHelperMock = new Mock<IRepositoryHelper>();
            var flights = GenerateFlightJson();
            repoHelperMock.Setup(x => x.ReadFileContent(It.IsAny<string>())).Returns(flights);
            repoHelperMock.Setup(x => x.SetJsonSerializerOptions()).Returns(repoHelper.SetJsonSerializerOptions());
            var flightRepo = new FlightRepository(repoHelperMock.Object);
            var departureDate = new DateTime(2023, 07, 01);
            List<string> departingFrom = new List<string> { "MAN" };
            var travelingTo = "AGP";

            //Act
            var results = flightRepo.SearchFlights(departureDate, departingFrom, travelingTo);

            //Assert
            Assert.True(results.First().Id == 3);
        }


        [Fact]
        public void SearchFlights_WhenAnyAirport_ReturnFlightsWithAnyDepartedFrom()
        {
            //Arrange
            var repoHelper = new RepositoryHelper();
            var repoHelperMock = new Mock<IRepositoryHelper>();
            var flights = GenerateFlightJson();
            repoHelperMock.Setup(x => x.ReadFileContent(It.IsAny<string>())).Returns(flights);
            repoHelperMock.Setup(x => x.SetJsonSerializerOptions()).Returns(repoHelper.SetJsonSerializerOptions());
            var flightRepo = new FlightRepository(repoHelperMock.Object);
            var departureDate = new DateTime(2023, 07, 03);
            List<string> departingFrom = new List<string>();
            var travelingTo = "AGP";

            //Act
            var results = flightRepo.SearchFlights(departureDate, departingFrom, travelingTo);

            //Assert
            Assert.True(results.First().Id == 7);
        }

        [Fact]
        public void SearchFlights_WhenAnyLondonAirport_ReturnFlightsWithAnyLondonAirport()
        {
            //Arrange
            var repoHelper = new RepositoryHelper();
            var repoHelperMock = new Mock<IRepositoryHelper>();
            var flights = GenerateFlightJson();
            repoHelperMock.Setup(x => x.ReadFileContent(It.IsAny<string>())).Returns(flights);
            repoHelperMock.Setup(x => x.SetJsonSerializerOptions()).Returns(repoHelper.SetJsonSerializerOptions());
            var flightRepo = new FlightRepository(repoHelperMock.Object);
            var departureDate = new DateTime(2023, 07, 03);
            List<string> departingFrom = new List<string> { "LTN", "LGW"};
            var travelingTo = "AGP";

            //Act
            var results = flightRepo.SearchFlights(departureDate, departingFrom, travelingTo);

            //Assert
            Assert.Equal(2, results.Count);
            Assert.True(results.First().Id == 7);
            Assert.True(results.Last().Id == 8);
        }

        private string GenerateFlightJson()
        {
            return @"[
            {
                ""id"": 1,
                ""from"": ""MAN"",
                ""to"": ""AGP"",
                ""departure_date"": ""2023-08-01""
            },
            {
                ""id"": 2,
                ""from"": ""MAN"",
                ""to"": ""AGP"",
                ""departure_date"": ""2023-06-01""
            },
            {
                ""id"": 3,
                ""from"": ""MAN"",
                ""to"": ""AGP"",
                ""departure_date"": ""2023-07-01""
            },
            {
                ""id"": 4,
                ""from"": ""LGW"",
                ""to"": ""AGP"",
                ""departure_date"": ""2023-07-01""
            },
            {
                ""id"": 5,
                ""from"": ""MAN"",
                ""to"": ""LPA"",
                ""departure_date"": ""2023-07-01""
            },
            {
                ""id"": 6,
                ""from"": ""MAN"",
                ""to"": ""AGP"",
                ""departure_date"": ""2023-07-02""
            },
            {
                ""id"": 7,
                ""from"": ""LGW"",
                ""to"": ""AGP"",
                ""departure_date"": ""2023-07-03""
            },
            {
                ""id"": 8,
                ""from"": ""LTN"",
                ""to"": ""AGP"",
                ""departure_date"": ""2023-07-04""
            }]";
        }
    }
}