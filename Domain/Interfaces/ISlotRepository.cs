// ISlotRepository.cs - placeholder file

using Booking.Domain.Entities;

namespace Booking.Domain.Interfaces
{
    public interface ISlotRepository : IRepository<AppointmentSlot>
    {
        Task<IReadOnlyList<AppointmentSlot>> GetAvailableSlotsAsync(int serviceId, DateTime from);
    }
}
