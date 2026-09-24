using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyHome.Domain.Models
{
    public class AccommodationImage
    {
        public Guid AccommodationImageId { get; private set; }

        public string ImageUrl { get; private set; } = string.Empty;

        public Guid AccommodationId { get; private set; }

        public Accommodation? Accommodation { get; private set; }

        private AccommodationImage()
        {
        }

        public AccommodationImage(
            string imageUrl,
            Guid accommodationId)
        {
            AccommodationImageId = Guid.NewGuid();
            ImageUrl = imageUrl;
            AccommodationId = accommodationId;
        }
    }    
    }

