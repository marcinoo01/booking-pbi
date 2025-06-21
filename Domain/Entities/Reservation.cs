
namespace Booking.Domain.Entities;

public class Reservation
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; } = default!;
    public int ServiceId { get; private set; }
    public Service Service { get; private set; } = default!;
    public int AppointmentSlotId { get; private set; }
    public AppointmentSlot AppointmentSlot { get; private set; } = default!;
    public DateTime ReservedAt { get; private set; }

    protected Reservation()
    {
    }

    public Reservation(int userId, int serviceId, int appointmentSlotId)
    {
        UserId = userId;
        ServiceId = serviceId;
        AppointmentSlotId = appointmentSlotId;
        ReservedAt = DateTime.UtcNow;
    }

    public void Cancel()
    {
    }
}