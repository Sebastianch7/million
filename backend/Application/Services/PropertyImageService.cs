using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IPropertyImageRepository _repository;
        private readonly IMapper _mapper;

        public PropertyImageService(IPropertyImageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyImageDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PropertyImageDto>>(entities);
        }

        public async Task<PropertyImageDto> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
                throw new NotFoundException($"No image found for property with id: {id}");
                
            return _mapper.Map<PropertyImageDto>(entity);
        }
    }
}
