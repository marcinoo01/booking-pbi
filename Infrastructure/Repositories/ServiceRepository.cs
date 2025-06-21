
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Booking.Infrastructure.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context) {}

        public async Task<Service?> GetByNameAsync(string name) =>
            await _dbSet.FirstOrDefaultAsync(s => s.Name == name);
    }

}