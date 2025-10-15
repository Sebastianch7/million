using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class PropertyTraceService : IPropertyTraceService
    {
        private readonly IPropertyTraceRepository _repository;
        private readonly IMapper _mapper;

        public PropertyTraceService(IPropertyTraceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyTraceDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PropertyTraceDto>>(entities);
        }

        public async Task<PropertyTraceDto> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                throw new NotFoundException($"Property section with id not found: {id}");

            return _mapper.Map<PropertyTraceDto>(entity);
        }
    }
}
