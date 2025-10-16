using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;

namespace Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;

        public PropertyService(IPropertyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PropertyDto>> GetAllAsync()
        {
            var properties = await _repository.GetAllAsync();
            return _mapper.Map<List<PropertyDto>>(properties);
        }

        public async Task<PropertyDto> GetByIdAsync(string id)
        {
            var property = await _repository.GetByIdAsync(id);

            if (property == null)
                throw new NotFoundException($"Property with ID {id} not found.");

            return _mapper.Map<PropertyDto>(property);
        }

        public async Task<List<PropertyDto>> GetFilteredAsync(PropertyFilterDto filter)
        {
            var properties = await _repository.GetFilteredAsync(
                filter.Name,
                filter.Address,
                filter.MinPrice,
                filter.MaxPrice
            );

            return _mapper.Map<List<PropertyDto>>(properties);
        }
    }
}
