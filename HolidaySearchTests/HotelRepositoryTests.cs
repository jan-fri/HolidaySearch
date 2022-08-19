using HolidaySearch.Repositories;

namespace HolidaySearchTests
{
    public class HotelRepositoryTests
    {
        [Fact]
        public void DeserializeHotelsJson_CheckMappings()
        {
            //Arrange
            var hotelRepo = new HotelRepository();

            //Act
            var allHotels = hotelRepo.GetHotelList();

            //Assert
            Assert.True(allHotels.All(x => x.Id.GetType() == typeof(int)));
            Assert.True(allHotels.All(x => !string.IsNullOrEmpty(x.Name)));
            Assert.True(allHotels.All(x => x.ArrivalDate.GetType() == typeof(DateOnly)));
            Assert.True(allHotels.All(x => x.PricePerNight.GetType() == typeof(decimal)));
            Assert.True(allHotels.All(x => !string.IsNullOrEmpty(x.LocalAirports)));
            Assert.True(allHotels.All(x => x.Nights.GetType() == typeof(int)));
        }
    }
}
