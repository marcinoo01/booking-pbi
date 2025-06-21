
using Booking.Domain.Entities;

namespace Booking.Domain.Interfaces;

public interface IReservationRepository : IRepository<Reservation>
{
    Task<IReadOnlyList<Reservation>> GetByUserAsync(int userId);

}