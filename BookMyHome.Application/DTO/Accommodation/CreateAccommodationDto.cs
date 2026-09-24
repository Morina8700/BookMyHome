namespace BookMyHome.Application.DTO.Accommodation
{
    public class CreateAccommodationDto
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public decimal PricePerNight { get; set; }

        public Guid HostId { get; set; }
    }
}
