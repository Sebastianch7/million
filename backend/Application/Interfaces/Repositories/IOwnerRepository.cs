using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllAsync();
        Task<Owner?> GetByIdAsync(string id);
    }
}
