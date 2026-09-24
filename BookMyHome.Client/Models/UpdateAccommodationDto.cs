namespace BookMyHome.Client.Models
{
    public class UpdateAccommodationDto
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public decimal PricePerNight { get; set; }
    }
}
