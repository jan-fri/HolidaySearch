using HolidaySearch.Helpers;
using HolidaySearch.Repositories;
using Moq;

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
        public void SearchHotels_ReturnListOfHotelsMatchingCriteria()
        {
            //Arrange
            var repoHelper = new RepositoryHelper();
            var repoHelperMock = new Mock<IRepositoryHelper>();
            var hotels = GenerateHotelJson();
            repoHelperMock.Setup(x => x.ReadFileContent(It.IsAny<string>())).Returns(hotels);
            repoHelperMock.Setup(x => x.SetJsonSerializerOptions()).Returns(repoHelper.SetJsonSerializerOptions());
            var hotelRepo = new HotelRepository(repoHelperMock.Object);
            var arrivalDate = new DateTime(2023, 07, 01);
            var arrivingAt = "AGP";
            var duration = 7;

            //Act
            var results = hotelRepo.SearchHotels(arrivalDate, arrivingAt, duration);

            //Assert
            Assert.NotNull(results);
            Assert.Equal(2, results.Count);
            Assert.True(results.All(x => x.ArrivalDate >= arrivalDate));
            Assert.True(results.All(x => x.Nights == duration));
            Assert.True(results.All(x => x.LocalAirports.Contains(arrivingAt)));
        }

        [Fact]
        public void SearchHotels_ReturnList_SortedByArrivalDate()
        {
            //Arrange
            var repoHelper = new RepositoryHelper();
            var repoHelperMock = new Mock<IRepositoryHelper>();
            var hotels = GenerateHotelJson();
            repoHelperMock.Setup(x => x.ReadFileContent(It.IsAny<string>())).Returns(hotels);
            repoHelperMock.Setup(x => x.SetJsonSerializerOptions()).Returns(repoHelper.SetJsonSerializerOptions());
            var hotelRepo = new HotelRepository(repoHelperMock.Object);
            var arrivalDate = new DateTime(2023, 07, 01);
            var arrivingAt = "AGP";
            var duration = 7;

            //Act
            var results = hotelRepo.SearchHotels(arrivalDate, arrivingAt, duration);

            //Assert
            Assert.True(results.First().Id == 5);
        }

        private string GenerateHotelJson()
        {
            return @"[
            {
                ""id"": 1,
                ""arrival_date"": ""2022-11-05"",
                ""local_airports"": [""TFS""],
                ""nights"": 7
            },
            {
                ""id"": 2,
                ""arrival_date"": ""2023-07-01"",
                ""local_airports"": [""PMI""],
                ""nights"": 14
            },
            {
                ""id"": 3,
                ""arrival_date"": ""2023-07-01"",
                ""local_airports"": [""AGP""],
                ""nights"": 14
            },
            {
                ""id"": 4,
                ""arrival_date"": ""2023-07-02"",
                ""local_airports"": [""AGP""],
                ""nights"": 7
            },
            {
                ""id"": 5,
                ""arrival_date"": ""2023-07-01"",
                ""local_airports"": [""AGP""],
                ""nights"": 7
            },
            {
                ""id"": 6,
                ""arrival_date"": ""2023-06-30"",
                ""local_airports"": [""AGP""],
                ""nights"": 7
            }]";
        }
    }
}
