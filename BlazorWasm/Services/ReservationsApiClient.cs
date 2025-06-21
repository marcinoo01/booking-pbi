using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Booking.SharedKernel.Models;
using Booking.SharedKernel.Requests;

namespace Booking.BlazorWasm.Services
{
    public class ReservationsApiClient
    {
        private readonly HttpClient _http;
        public ReservationsApiClient(HttpClient http) => _http = http;

        public Task<ReservationDto?> CreateAsync(CreateReservationRequest req)
        
            => _http.PostAsJsonAsync("api/reservations", req)
                .ContinueWith(t => t.Result.Content.ReadFromJsonAsync<ReservationDto>())
                .Unwrap();
    }
}
