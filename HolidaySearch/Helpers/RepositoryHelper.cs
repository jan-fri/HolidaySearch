using System.Text.Json;

namespace HolidaySearch.Helpers
{
    public class RepositoryHelper : IRepositoryHelper
    {
        public string ReadFileContent(string fileName)
        {
            var root = FindSolutionDirectory();
            var flightListSource = Path.Combine(root, "HolidaySearch", "Content", fileName);
            return File.ReadAllText(flightListSource);
        }

        private string FindSolutionDirectory()
        {
            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            while (directory != null && !directory.GetFiles("HolidaySearch.sln").Any())
            {
                directory = directory.Parent;
            }
            if (directory == null)
                throw new Exception("HolidaySearch was not found");

            return directory.FullName;
        }

        public JsonSerializerOptions SetJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
    }
}
