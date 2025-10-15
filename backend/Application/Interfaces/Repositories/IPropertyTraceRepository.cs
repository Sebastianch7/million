using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IPropertyTraceRepository
    {
        Task<IEnumerable<PropertyTrace>> GetAllAsync();
        Task<PropertyTrace?> GetByIdAsync(string id);
    }
}
