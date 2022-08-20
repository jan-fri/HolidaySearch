using System.Text.Json.Serialization;

namespace HolidaySearch.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public string Airline { get; set; } = null!;

        [JsonPropertyName("from")]
        public string DepartingFrom { get; set; } = null!;

        [JsonPropertyName("to")]
        public string TravalingTo { get; set; } = null!;
        public decimal Price { get; set; }

        [JsonPropertyName("departure_date")]
        public DateTime DepartureDate { get; set; }
    }
}
