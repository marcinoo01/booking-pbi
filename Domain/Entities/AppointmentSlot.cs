
using System.Text.Json.Serialization;

namespace Booking.Domain.Entities;

public class AppointmentSlot
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsReserved { get; set; }

    public AppointmentSlot() { }

    public AppointmentSlot(int serviceId, DateTime startTime, int durationMinutes)
    {
        ServiceId = serviceId;
        StartTime = startTime;
        EndTime = startTime.AddMinutes(durationMinutes);
        IsReserved = false;
    }

    public void MarkReserved() => IsReserved = true;
    public void MarkAvailable() => IsReserved = false;

    public bool IsInPast() => StartTime < DateTime.UtcNow;
}