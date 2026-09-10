using BookMyHome.Domain.Exceptions;
using BookMyHome.Domain.Models;
using BookMyHome.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using BookMyHome.Application.DTO;

namespace BookMyHome.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly BookingRepository _repository;

        public BookingsController(BookingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetAll()
        {
            var bookings = await _repository.GetAllAsync();

            return Ok(bookings);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Booking>> GetById(Guid id)
        {
            var booking = await _repository.GetByIdAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Create(BookingDto dto)
        {
            var booking = new Booking(
                dto.StartDate,
                dto.EndDate,
                dto.AccommodationId);

            try
            {
                await _repository.AddAsync(booking);
            }
            catch (OverlapingBookingException ex)
            {
                return Conflict(ex.Message);
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = booking.BookingId },
                booking);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var booking = await _repository.GetByIdAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
    Guid id,
    UpdateBookingDto dto)
        {
            var existingBooking = await _repository.GetByIdAsync(id);

            if (existingBooking == null)
            {
                return NotFound();
            }

            try
            {
                await _repository.UpdateAsync(
                    id,
                    dto.StartDate,
                    dto.EndDate,
                    dto.AccommodationId);
            }
            catch (OverlapingBookingException ex)
            {
                return Conflict(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }





    }
}
