using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IPropertyImageRepository
    {
        Task<List<PropertyImage>> GetAllAsync();
        Task<PropertyImage?> GetByIdAsync(string id);
    }
}
