using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceService : GenericService<Service, ServiceDto>, IServiceService
    {
        private readonly IServiceRepository _repository;
        public ServiceService(IServiceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<ServiceDto> GetByIdAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public override async Task<IEnumerable<ServiceDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public override async Task<ServiceDto> AddAsync(ServiceDto dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public override async Task<ServiceDto> UpdateAsync(ServiceDto dto)
        {
            var entity = MapToEntity(dto);
            await _repository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public override async Task<bool> DeleteAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            await _repository.DeleteAsync(entity);
            return true;
        }

        private ServiceDto MapToDto(Service entity)
        {
            return new ServiceDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                DurationMinutes = entity.DurationMinutes,
                CategoryId = entity.CategoryId,
                CategoryName = entity.Category != null ? entity.Category.Name : null,
                Tags = entity.Tags,
                ImageUrl = entity.ImageUrl,
                IsActive = entity.IsActive
            };
        }

        private Service MapToEntity(ServiceDto dto)
        {
            return new Service
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                DurationMinutes = dto.DurationMinutes,
                CategoryId = dto.CategoryId,
                Tags = dto.Tags,
                ImageUrl = dto.ImageUrl,
                IsActive = dto.IsActive
            };
        }
    }
} 