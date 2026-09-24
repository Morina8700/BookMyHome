namespace BookMyHome.Application.DTO.Booking
{
    public class BookingDto
    {
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Guid AccommodationId { get; set; }
    }
}
