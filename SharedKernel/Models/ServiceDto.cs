namespace Booking.SharedKernel.Models
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int DurationMinutes { get; set; }
    }
}