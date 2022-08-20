using HolidaySearch;
using HolidaySearch.Helpers;
using HolidaySearch.Repositories;
using HolidaySearch.Services;

namespace HolidaySearchTests
{
    public class HolidaySearchTests
    {
        [Fact]
        public void PerformHolidaySearch_ForCustomer1()
        {
            //Arrange
            var holiday = SetupHoliday();

            //Act
            var holidaySearch = holiday.Search(new List<string> { "MAN" }, "AGP", new DateTime(2023, 07, 01), 7);

            //Assert
            Assert.Equal(826, holidaySearch.First().TotalPrice);
            Assert.Equal(2, holidaySearch.First().Flight.Id);
            Assert.Equal("MAN", holidaySearch.First().Flight.DepartingFrom);
            Assert.Equal("AGP", holidaySearch.First().Flight.TravalingTo);
            Assert.Equal(245, holidaySearch.First().Flight.Price);
            Assert.Equal(9, holidaySearch.First().Hotel.Id);
            Assert.Equal("Nh Malaga", holidaySearch.First().Hotel.Name);
            Assert.Equal(83, holidaySearch.First().Hotel.PricePerNight);
        }

        [Fact]
        public void PerformHolidaySearch_ForCustomer2()
        {
            //Arrange
            var holiday = SetupHoliday();

            //Act
            var holidaySearch = holiday.Search(new List<string> { "LGW", "LTN" }, "PMI", new DateTime(2023, 06, 15), 10);

            //Assert
            Assert.Equal(675, holidaySearch.First().TotalPrice);
            Assert.Equal(6, holidaySearch.First().Flight.Id);
            Assert.Equal("LGW", holidaySearch.First().Flight.DepartingFrom);
            Assert.Equal("PMI", holidaySearch.First().Flight.TravalingTo);
            Assert.Equal(75, holidaySearch.First().Flight.Price);
            Assert.Equal(5, holidaySearch.First().Hotel.Id);
            Assert.Equal("Sol Katmandu Park & Resort", holidaySearch.First().Hotel.Name);
            Assert.Equal(60, holidaySearch.First().Hotel.PricePerNight);
        }

        [Fact]
        public void PerformHolidaySearch_ForCustomer3()
        {
            //Arrange
            var holiday = SetupHoliday();

            //Act
            var holidaySearch = holiday.Search(new List<string>(), "LPA", new DateTime(2022, 11, 10), 14);

            //Assert
            Assert.Equal(1175, holidaySearch.First().TotalPrice);
            Assert.Equal(7, holidaySearch.First().Flight.Id);
            Assert.Equal("MAN", holidaySearch.First().Flight.DepartingFrom);
            Assert.Equal("LPA", holidaySearch.First().Flight.TravalingTo);
            Assert.Equal(125, holidaySearch.First().Flight.Price);
            Assert.Equal(6, holidaySearch.First().Hotel.Id);
            Assert.Equal("Club Maspalomas Suites and Spa", holidaySearch.First().Hotel.Name);
            Assert.Equal(75, holidaySearch.First().Hotel.PricePerNight);
        }

        private Holiday SetupHoliday()
        {
            var repoHelper = new RepositoryHelper();
            var flightRepo = new FlightRepository(repoHelper);
            var hotelRepo = new HotelRepository(repoHelper);
            var holidaySearchService = new HolidaySearchService(flightRepo, hotelRepo);
            return new Holiday(holidaySearchService);
        }
    }
}
