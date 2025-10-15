using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPropertyTraceService
    {
        Task<IEnumerable<PropertyTraceDto>> GetAllAsync();
        Task<PropertyTraceDto> GetByIdAsync(string id);
    }
}
