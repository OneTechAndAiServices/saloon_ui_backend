using Application.Interfaces;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TDto>
        where TEntity : class, new()
        where TDto : class, new()
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TDto> GetByIdAsync(long id)
        {
            // Map entity to DTO
            return new TDto();
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            // Map entities to DTOs
            return new List<TDto>();
        }

        public virtual async Task<TDto> AddAsync(TDto dto)
        {
            // Map DTO to entity and add
            return dto;
        }

        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            // Map DTO to entity and update
            return dto;
        }

        public virtual async Task<bool> DeleteAsync(long id)
        {
            // Delete entity by id
            return true;
        }
    }
} 