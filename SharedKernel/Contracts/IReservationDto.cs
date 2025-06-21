// IReservationDto.cs - placeholder file
namespace Booking.SharedKernel.Contracts
{
    public interface IReservationDto
    {
        int Id { get; set; }
        int UserId { get; set; }
        int ServiceId { get; set; }
        int AppointmentSlotId { get; set; }
        DateTime ReservedAt { get; set; }
    }
}