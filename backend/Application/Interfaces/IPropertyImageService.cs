using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPropertyImageService
    {
        Task<List<PropertyImageDto>> GetAllAsync();
        Task<PropertyImageDto> GetByIdAsync(string id);
    }
}
