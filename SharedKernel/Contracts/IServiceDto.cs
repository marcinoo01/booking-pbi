namespace Booking.SharedKernel.Contracts
{
    public interface IServiceDto
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int DurationMinutes { get; set; }
    }
}