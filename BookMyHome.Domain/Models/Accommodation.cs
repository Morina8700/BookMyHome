using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyHome.Domain.Models
{
    public class Accommodation
    {
        public Guid AccommodationId { get; private set; }

        public string? Name { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }
        = new List<Booking>();

        public Accommodation () { }

        public Accommodation(string name)
        {
            AccommodationId = Guid.NewGuid();
            Name = name;
        }
    }
}
