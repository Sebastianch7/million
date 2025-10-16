using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _repository;
        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OwnerDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<OwnerDto>>(entities);
        }

        public async Task<OwnerDto> GetByIdAsync(string id)
        {
            var owner = await _repository.GetByIdAsync(id);

            if (owner == null)
                throw new NotFoundException($"Owner with id not found: {id}");

            return _mapper.Map<OwnerDto>(owner);
        }
    } 
}
