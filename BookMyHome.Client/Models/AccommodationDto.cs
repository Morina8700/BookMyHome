namespace BookMyHome.Client.Models
{
    public class AccommodationDto
    {
        public Guid AccommodationId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public decimal PricePerNight { get; set; }

        public Guid HostId { get; set; }
    }
}
