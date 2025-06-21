
using Booking.Domain.Entities;

namespace Booking.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Service> Services { get; }
        IRepository<AppointmentSlot> AppointmentSlots { get; }
        IRepository<Reservation> Reservations { get; }
        Task<int> SaveChangesAsync();
    }
}