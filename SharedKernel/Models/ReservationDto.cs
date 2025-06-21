
using Booking.SharedKernel.Contracts;

namespace Booking.SharedKernel.Models
{
    public class ReservationDto : IReservationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public int AppointmentSlotId { get; set; }
        public DateTime ReservedAt { get; set; }
    }
}