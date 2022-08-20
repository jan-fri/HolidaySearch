using System.Text.Json;

namespace HolidaySearch.Helpers
{
    public interface IRepositoryHelper
    {
        string ReadFileContent(string fileName);
        JsonSerializerOptions SetJsonSerializerOptions();
    }
}
