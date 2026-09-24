using BookMyHome.Application.DTO.Accommodation;
using BookMyHome.Domain.Models;
using BookMyHome.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookMyHome.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccommodationsController : ControllerBase
    {
        private readonly AccommodationRepository _repository;

        public AccommodationsController(AccommodationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var accommodation = await _repository.GetAllAsync();

            return Ok(accommodation);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var accommodation = await _repository.GetByIdAsync(id);

            if (accommodation == null)
                return NotFound();

            return Ok(accommodation);
        }

        [HttpPost]
        public async Task<ActionResult> Create(
       CreateAccommodationDto dto)
        {
            try
            {
                var accommodation = new Accommodation(
                    dto.Name,
                    dto.Address,
                    dto.PricePerNight,
                    dto.HostId);

                await _repository.AddAsync(accommodation);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = accommodation.AccommodationId },
                    accommodation);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
    Guid id,
    UpdateAccommodationDto dto)
        {
            try
            {
                await _repository.UpdateAsync(
                    id,
                    dto.Name,
                    dto.Address,
                    dto.PricePerNight);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var accommodation = await _repository.GetByIdAsync(id);

            if (accommodation == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{id:guid}/bookings")]
        public async Task<ActionResult> GetBookings(Guid id)
        {
            var accommodation = await _repository.GetByIdAsync(id);

            if (accommodation == null)
                return NotFound();

            var bookings = await _repository.GetBookingsAsync(id);

            return Ok(bookings);
        }
    }
}
