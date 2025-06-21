using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Booking.SharedKernel.Models;

namespace Booking.BlazorWasm.Services
{
    public class ServicesApiClient
    {
        private readonly HttpClient _http;
        public ServicesApiClient(HttpClient http) => _http = http;

        public Task<List<ServiceDto>?> GetAllAsync()
            => _http.GetFromJsonAsync<List<ServiceDto>>("api/services");

        public Task<ServiceDto?> GetByIdAsync(int id)
            => _http.GetFromJsonAsync<ServiceDto>($"api/services/{id}");

        public async Task<ServiceDto?> CreateAsync(ServiceDto dto)
        {
            var resp = await _http.PostAsJsonAsync("api/services", dto);
            return resp.IsSuccessStatusCode
                ? await resp.Content.ReadFromJsonAsync<ServiceDto>()
                : null;
        }
    }
}