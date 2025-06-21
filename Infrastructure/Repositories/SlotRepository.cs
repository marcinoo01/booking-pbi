
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repositories
{
    public class SlotRepository : Repository<AppointmentSlot>, ISlotRepository
    {
        public SlotRepository(AppDbContext context) : base(context) {}

        public async Task<IReadOnlyList<AppointmentSlot>> GetAvailableSlotsAsync(int serviceId, DateTime from) =>
            await _dbSet
                .Where(a => a.ServiceId == serviceId && !a.IsReserved && a.StartTime >= from)
                .ToListAsync();
    }

}