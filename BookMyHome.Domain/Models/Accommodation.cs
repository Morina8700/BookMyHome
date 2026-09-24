using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyHome.Domain.Models
{

    public class Accommodation
    {
        public Guid AccommodationId { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string Address { get; private set; } = string.Empty;

        public decimal PricePerNight { get; private set; }

        public Guid HostId { get; private set; }

        public Host? Host { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }
            = new List<Booking>();

        private Accommodation()
        {
        }

        public Accommodation(
            string name,
            string address,
            decimal pricePerNight,
            Guid hostId)
        {
            AccommodationId = Guid.NewGuid();

            Update(name, address, pricePerNight);

            HostId = hostId;
        }

        public void Update(
            string name,
            string address,
            decimal pricePerNight)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address is required.");

            if (pricePerNight <= 0)
                throw new ArgumentException(
                    "Price per night must be greater than 0.");

            Name = name;
            Address = address;
            PricePerNight = pricePerNight;
        }
    }
}
