namespace HolidaySearch.Entities
{
    public class HolidaySearchReslut
    {
        public decimal TotalPrice
        {
            get
            {
                return Flight.Price + Hotel.PricePerNight * Hotel.Nights;
            }
        }

        public Flight Flight { get; set; } = null!;
        public Hotel Hotel { get; set; } = null!;

    }
}
