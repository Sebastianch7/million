using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IPropertyImageRepository
    {
        Task<IEnumerable<PropertyImage>> GetAllAsync();
        Task<PropertyImage?> GetByIdAsync(string id);
    }
}
