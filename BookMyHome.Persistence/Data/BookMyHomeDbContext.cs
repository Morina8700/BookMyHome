using BookMyHome.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMyHome.Persistence.Data
{
    public class BookMyHomeDbContext : DbContext
    {
        public BookMyHomeDbContext(
        DbContextOptions<BookMyHomeDbContext> options)
        : base(options)
        {
        }

        public DbSet<Booking> Bookings => Set<Booking>();

        public DbSet<Accommodation> Accommodations
            => Set<Accommodation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var accommodation1Id =
    Guid.Parse("11111111-1111-1111-1111-111111111111");

            var accommodation2Id =
                Guid.Parse("22222222-2222-2222-2222-222222222222");

            modelBuilder.Entity<Accommodation>().HasData(
    new
    {
        AccommodationId = accommodation1Id,
        Name = "Beach House"
    },
    new
    {
        AccommodationId = accommodation2Id,
        Name = "City Apartment"
    }
);

            var booking1Id =
    Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            var booking2Id =
                Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

            modelBuilder.Entity<Booking>().HasData(
    new
    {
        BookingId = booking1Id,
        StartDate = new DateOnly(2027, 6, 1),
        EndDate = new DateOnly(2027, 6, 5),
        AccommodationId = accommodation1Id
    },
    new
    {
        BookingId = booking2Id,
        StartDate = new DateOnly(2027, 7, 10),
        EndDate = new DateOnly(2027, 7, 15),
        AccommodationId = accommodation1Id
    }
);

            modelBuilder.Entity<Booking>()
                .HasKey(b => b.BookingId);

            modelBuilder.Entity<Accommodation>()
                .HasKey(a => a.AccommodationId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Accommodation)
                .WithMany(a => a.Bookings)
                .HasForeignKey(b => b.AccommodationId);

        }

    }
}
