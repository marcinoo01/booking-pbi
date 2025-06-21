using Booking.Domain.Entities;
using Booking.Domain.Interfaces;

namespace Booking.Application.Services
{
    public class SlotManagementService
    {
        private readonly IUnitOfWork _uow;
        public SlotManagementService(IUnitOfWork uow) => _uow = uow;

        public async Task<AppointmentSlot> CreateSlotAsync(int serviceId, DateTime startTime)
        {
            var service = await _uow.Services.GetByIdAsync(serviceId)
                          ?? throw new InvalidOperationException("Service not found");
            var slot = new AppointmentSlot(serviceId, startTime, service.DurationMinutes);
            await _uow.AppointmentSlots.AddAsync(slot);
            await _uow.SaveChangesAsync();
            return slot;
        }

        public async Task<IEnumerable<AppointmentSlot>> GetAvailableAsync(int serviceId, DateTime from)
        {
            return await ((ISlotRepository)_uow.AppointmentSlots)
                .GetAvailableSlotsAsync(serviceId, from);
        }
    }

}