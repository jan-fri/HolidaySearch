using System.Text.Json.Serialization;

namespace HolidaySearch.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [JsonPropertyName("arrival_date")]
        public DateTime ArrivalDate { get; set; }
        [JsonPropertyName("price_per_night")]
        public decimal PricePerNight { get; set; }
        [JsonPropertyName("local_airports")]
        public List<string> LocalAirports { get; set; } = null!;
        public int Nights { get; set; }
    }
}
