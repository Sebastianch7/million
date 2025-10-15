using Application.DTOs;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerDto>> GetAllAsync();
        Task<OwnerDto> GetByIdAsync(string id);
    }
}
