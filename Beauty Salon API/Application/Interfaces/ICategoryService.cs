using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(long id);
        Task<CategoryDto> AddAsync(CategoryDto dto);
        Task<CategoryDto> UpdateAsync(CategoryDto dto);
        Task<bool> DeleteAsync(long id);
    }
} 