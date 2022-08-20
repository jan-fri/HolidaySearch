using HolidaySearch.Helpers;
using HolidaySearch.Repositories;
using HolidaySearch.Services;

namespace HolidaySearchTests
{
    public class HolidaySearchServiceTests
    {
        [Fact]
        public void HolidaySearch_ShouldReturn_FlightId2_And_HotelId9()
        {
            //Arrange
            HolidaySearchService holidaySearchService = SetupHolidayService();
            List<string> departingFrom = new List<string> { "MAN" };
            var travelingTo = "AGP";
            var departingDate = new DateTime(2023, 07, 01);
            var duration = 7;

            //Act
            var results = holidaySearchService.SearchHoliday(departingFrom, travelingTo, departingDate, duration);

            //Assert
            Assert.Equal(2, results.First().Flight.Id);
            Assert.Equal(9, results.First().Hotel.Id);
        }

        [Fact]
        public void HolidaySearch_ShouldReturn_FlightId6_And_HotelId5()
        {
            //Arrange
            HolidaySearchService holidaySearchService = SetupHolidayService();
            List<string> departingFrom = new List<string> { "LGW", "LTN" };
            var travelingTo = "PMI";
            var departingDate = new DateTime(2023, 06, 15);
            var duration = 10;

            //Act
            var results = holidaySearchService.SearchHoliday(departingFrom, travelingTo, departingDate, duration);

            //Assert
            Assert.Equal(6, results.First().Flight.Id);
            Assert.Equal(5, results.First().Hotel.Id);
        }

        [Fact]
        public void HolidaySearch_ShouldReturn_Flight7_And_Hotel6()
        {
            //Arrange
            HolidaySearchService holidaySearchService = SetupHolidayService();
            List<string> departingFrom = new List<string>();
            var travelingTo = "LPA";
            var departingDate = new DateTime(2022, 11, 10);
            var duration = 14;

            //Act
            var results = holidaySearchService.SearchHoliday(departingFrom, travelingTo, departingDate, duration);

            //Assert
            Assert.Equal(7, results.First().Flight.Id);
            Assert.Equal(6, results.First().Hotel.Id);
        }

        private HolidaySearchService SetupHolidayService()
        {
            var repoHelper = new RepositoryHelper();
            var flightRepo = new FlightRepository(repoHelper);
            var hotelRepo = new HotelRepository(repoHelper);
            return new HolidaySearchService(flightRepo, hotelRepo);
        }
    }
}
