using System.Net.Http.Json;
using BookMyHome.Client.Models;

namespace BookMyHome.Client.Services
{
    public class BookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BookingDto>> GetAllAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<List<BookingDto>>("api/bookings")
                ?? new List<BookingDto>();
        }
        public async Task<HttpResponseMessage> CreateAsync(
    CreateBookingDto booking)
        {
            return await _httpClient.PostAsJsonAsync(
                "api/bookings",
                booking);
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/bookings/{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<BookingDto?> GetByIdAsync(Guid id)
        {
            return await _httpClient
                .GetFromJsonAsync<BookingDto>($"api/bookings/{id}");
        }

        public async Task<HttpResponseMessage> UpdateAsync(
            Guid id,
            UpdateBookingDto booking)
        {
            return await _httpClient.PutAsJsonAsync(
                $"api/bookings/{id}",
                booking

                );
        }



    }
}
