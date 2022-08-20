using HolidaySearch.Helpers;
using HolidaySearch.Repositories;

namespace HolidaySearchTests
{
    public class HotelRepositoryTests
    {
        [Fact]
        public void DeserializeHotelsJson_VerifyMappings()
        {
            //Arrange
            var repoHelper = new RepositoryHelper();
            var hotelRepo = new HotelRepository(repoHelper);

            //Act
            var allHotels = hotelRepo.GetHotelList();

            //Assert
            Assert.True(allHotels.All(x => x.Id.GetType() == typeof(int)));
            Assert.True(allHotels.All(x => !string.IsNullOrEmpty(x.Name)));
            Assert.True(allHotels.All(x => x.ArrivalDate.GetType() == typeof(DateTime)));
            Assert.True(allHotels.All(x => x.PricePerNight.GetType() == typeof(decimal)));
            Assert.True(allHotels.All(x => x.LocalAirports.All(y => !string.IsNullOrEmpty(y))));
            Assert.True(allHotels.All(x => x.Nights.GetType() == typeof(int)));
        }

        [Fact]
        public void SearchFlights_ReturnListOfHotelsMatchingCriteria()
        {
            //Arrange
            var repoHelper = new RepositoryHelper();
            var hotelRepo = new HotelRepository(repoHelper);
            var arrivalDate = new DateTime(2023, 07, 01);
            var arrivingAt = "AGP";
            var duration = 7;

            //Act
            var results = hotelRepo.SearchHotels(arrivalDate, arrivingAt, duration);

            //Assert
            Assert.NotNull(results);
            Assert.True(results.All(x => x.ArrivalDate == arrivalDate));
            Assert.True(results.All(x => x.Nights == duration));
            Assert.True(results.All(x => x.LocalAirports.Contains(arrivingAt)));
        }
    }
}
