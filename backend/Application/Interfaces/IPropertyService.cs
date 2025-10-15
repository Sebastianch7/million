using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyDto>> GetAllAsync();
        Task<PropertyDto> GetByIdAsync(string id);
    }
}
