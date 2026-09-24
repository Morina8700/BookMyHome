namespace BookMyHome.Client.Models
{
    public class CreateBookingDto
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public Guid AccommodationId { get; set; }
    }
}
