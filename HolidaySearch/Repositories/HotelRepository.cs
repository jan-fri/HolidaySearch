using HolidaySearch.Entities;
using HolidaySearch.Helpers;
using System.Text.Json;

namespace HolidaySearch.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IRepositoryHelper _repositoryHelper;
        public HotelRepository(IRepositoryHelper repositoryHelper)
        {
            _repositoryHelper = repositoryHelper;
        }
        public List<Hotel> GetHotelList()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var flightListSource = _repositoryHelper.ReadFileContent("hotels.json");
            return JsonSerializer.Deserialize<List<Hotel>>(flightListSource, options);
        }
    }
}
