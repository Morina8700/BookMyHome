namespace BookMyHome.Application.DTO.Accommodation
{
    public class UpdateAccommodationDto
    {
        public string Name { get; set; } = string.Empty;

        public string Address {  get; set; } = string.Empty;

        public decimal PricePerNight { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
