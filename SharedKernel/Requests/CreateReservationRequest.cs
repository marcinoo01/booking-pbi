namespace Booking.SharedKernel.Requests
{
    public class CreateReservationRequest
    {
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public int AppointmentSlotId { get; set; }
    }
}