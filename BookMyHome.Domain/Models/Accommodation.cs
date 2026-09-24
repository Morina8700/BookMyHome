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

        public string Description { get; private set; } = string.Empty;

        public ICollection<AccommodationImage> Images { get; private set; }
       = new List<AccommodationImage>();

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
     string description,
     decimal pricePerNight,
     Guid hostId)
        {
            AccommodationId = Guid.NewGuid();

            Update(
                name,
                address,
                description,
                pricePerNight);

            HostId = hostId;
        }

        public void Update(
    string name,
    string address,
    string description,
    decimal pricePerNight)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address is required.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.");

            if (pricePerNight <= 0)
                throw new ArgumentException(
                    "Price per night must be greater than 0.");

            Name = name;
            Address = address;
            Description = description;
            PricePerNight = pricePerNight;
        }
    }
}
