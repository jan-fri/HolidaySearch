using System.Text.Json.Serialization;

namespace HolidaySearch.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public string Airline { get; set; } = null!;
        public string From { get; set; } = null!;
        public string To { get; set; } = null!;
        public decimal Price { get; set; }
        [JsonPropertyName("departure_date")]
        public DateTime DepartureDate { get; set; }
    }
}
