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
        public DbSet<Host> Hosts => Set<Host>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .Property(b => b.RowVersion)
                .IsRowVersion();

            modelBuilder.Entity<User>()
                 .HasKey(u => u.UserId);

            modelBuilder.Entity<Accommodation>()
                .HasKey(a => a.AccommodationId);

            modelBuilder.Entity<Booking>()
                .HasKey(b => b.BookingId);

            modelBuilder.Entity<Accommodation>()
                .HasOne(a => a.Host)
                .WithMany(h => h.Accommodations)
                .HasForeignKey(a => a.HostId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Accommodation)
                .WithMany(a => a.Bookings)
                .HasForeignKey(b => b.AccommodationId);

            // Faste IDs til seed data
            var host1Id =
                Guid.Parse("33333333-3333-3333-3333-333333333333");

            var accommodation1Id =
                Guid.Parse("11111111-1111-1111-1111-111111111111");

            var accommodation2Id =
                Guid.Parse("22222222-2222-2222-2222-222222222222");

            var booking1Id =
                Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            var booking2Id =
                Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");


            // RELATION: Host -> Accommodations
            modelBuilder.Entity<Accommodation>()
                .HasOne(a => a.Host)
                .WithMany(h => h.Accommodations)
                .HasForeignKey(a => a.HostId);


            // RELATION: Accommodation -> Bookings
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Accommodation)
                .WithMany(a => a.Bookings)
                .HasForeignKey(b => b.AccommodationId);


            // HOST
            modelBuilder.Entity<Host>().HasData(
                new
                {
                    UserId = host1Id,
                    Name = "Test Host",
                    Email = "host@bookmyhome.dk"
                }
            );


            // ACCOMMODATIONS
            modelBuilder.Entity<Accommodation>().HasData(
                new
                {
                    AccommodationId = accommodation1Id,
                    Name = "Beach House",
                    Address = "Beach Road 1",
                    PricePerNight = 1200m,
                    HostId = host1Id
                },

                new
                {
                    AccommodationId = accommodation2Id,
                    Name = "City Apartment",
                    Address = "Main Street 10",
                    PricePerNight = 850m,
                    HostId = host1Id
                }
            );


            // BOOKINGS
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

        }

    }
}
