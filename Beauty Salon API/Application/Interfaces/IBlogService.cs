using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDto>> GetAllAsync();
        Task<BlogDto> GetByIdAsync(long id);
        Task<BlogDto> AddAsync(BlogDto dto);
        Task<BlogDto> UpdateAsync(BlogDto dto);
        Task<bool> DeleteAsync(long id);
    }
} 