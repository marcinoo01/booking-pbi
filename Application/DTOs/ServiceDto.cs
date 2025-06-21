using Booking.SharedKernel.Contracts;

namespace Booking.Application.DTOs
{
    public class ServiceDto : IServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
    }
}