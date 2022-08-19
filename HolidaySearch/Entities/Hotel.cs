namespace HolidaySearch.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime ArrivalDate { get; set; }
        public decimal PricePerNight { get; set; }
        public string LocalAirports { get; set; } = null!;
        public int Nights { get; set; }
    }
}
