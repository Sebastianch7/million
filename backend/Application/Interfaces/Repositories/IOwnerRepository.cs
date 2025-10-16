using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IOwnerRepository
    {
        Task<List<Owner>> GetAllAsync();
        Task<Owner?> GetByIdAsync(string id);
    }
}
