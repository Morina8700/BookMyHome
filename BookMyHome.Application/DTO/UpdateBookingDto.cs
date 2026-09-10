namespace BookMyHome.Application.DTO
{
    public class UpdateBookingDto
    {
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Guid AccommodationId { get; set; }
    }
}
