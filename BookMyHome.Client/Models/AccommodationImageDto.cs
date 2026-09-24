namespace BookMyHome.Client.Models
{
    public class AccommodationImageDto
    {
        public Guid AccommodationImageId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public Guid AccommodationId { get; set; }
    }
}
