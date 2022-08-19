using HolidaySearch.Helpers;

namespace HolidaySearchTests
{
    public class RepositoryHelperTests
    {
        [Fact]
        public void ReadJsonFile_GetFlightsContent_CheckIfNotEmpty()
        {
            //Arrange
            var repoHelper = new RepositoryHelper();

            //Act
            var flightsFileContent = repoHelper.ReadFileContent("flights.json");

            //Assert
            Assert.NotEmpty(flightsFileContent);
        }

        [Fact]
        public void ReadJsonFile_GetHotelsContent_CheckIfNotEmpty()
        {
            //Arrange
            var repoHelper = new RepositoryHelper();

            //Act
            var hotelsFileContent = repoHelper.ReadFileContent("hotels.json");

            //Assert
            Assert.NotEmpty(hotelsFileContent);
        }
    }
}
