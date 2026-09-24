namespace BookMyHome.Application.DTO.Booking
{
    public class UpdateBookingDto
    {
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Guid AccommodationId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}
