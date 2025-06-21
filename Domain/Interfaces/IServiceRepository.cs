// IServiceRepository.cs - placeholder file

using Booking.Domain.Entities;

namespace Booking.Domain.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<Service?> GetByNameAsync(string name);
    }
}