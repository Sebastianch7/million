using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPropertyService
    {
        Task<List<PropertyDto>> GetAllAsync();
        Task<PropertyDto> GetByIdAsync(string id);
        Task<List<PropertyDto>> GetFilteredAsync(PropertyFilterDto filter);
    }
}
