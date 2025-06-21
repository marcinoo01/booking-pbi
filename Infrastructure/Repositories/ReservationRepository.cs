
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context) {}

        public async Task<IReadOnlyList<Reservation>> GetByUserAsync(int userId) =>
            await _dbSet
                .Include(r => r.AppointmentSlot)
                .Include(r => r.Service)
                .Where(r => r.UserId == userId)
                .ToListAsync();
    }

}