namespace BookMyHome.Client.Models
{
    public class BookingDto
    {
        public Guid BookingId { get; set; }
        public DateOnly StartDate {  get; set; }
        public DateOnly EndDate {  get; set; }

        public Guid AccommodationId { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

    }
}
