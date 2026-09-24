using BookMyHome.Domain.Models;
using BookMyHome.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyHome.Persistence.Repositories
{
    public class AccommodationRepository
    {
        private readonly BookMyHomeDbContext _context;

        public AccommodationRepository(BookMyHomeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Accommodation>> GetAllAsync()
        {
            return await _context.Accommodations
            .Include(a => a.Host)
            .ToListAsync();
        }

        public async Task<Accommodation?> GetByIdAsync(Guid id)
        {
            return await _context.Accommodations
                .Include(b => b.Host)
                .FirstOrDefaultAsync(b => b.AccommodationId == id);
        }

        public async Task AddAsync(Accommodation newAccommodation)
        {
            _context.Accommodations.Add(newAccommodation);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(
            Guid id,
            string name,
            string address,
            decimal pricePerNight
            )
        {
            var accommodation = await _context.Accommodations
                .FirstOrDefaultAsync(a => a.AccommodationId == id);

            if( accommodation == null )
            {
                throw new KeyNotFoundException();
            }
            accommodation.Update(name, address, pricePerNight);

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(Guid id)
        {
            var accommodation = await _context.Accommodations
                .FirstOrDefaultAsync(a => a.AccommodationId ==id);

            if (accommodation == null)
                return;

            _context.Accommodations.Remove(accommodation);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetBookingsAsync(Guid accommodationId)
        {
            return await _context.Bookings
                .Where(b => b.AccommodationId == accommodationId)
                .ToListAsync();
        }


    }
}
