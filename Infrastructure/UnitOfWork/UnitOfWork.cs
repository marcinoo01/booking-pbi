
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.Repositories;

namespace Booking.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IRepository<User> Users { get; }
    public IRepository<Service> Services { get; }
    public IRepository<AppointmentSlot> AppointmentSlots { get; }
    public IRepository<Reservation> Reservations { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Users = new UserRepository(context);
        Services = new ServiceRepository(context);
        AppointmentSlots = new SlotRepository(context);
        Reservations = new ReservationRepository(context);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}