using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(long id);
        Task<UserDto> UpdateAsync(UserDto dto);
        Task<bool> DeleteAsync(long id);
        Task<UserDto> AddAsync(UserDto dto);

        // Advanced queries
        Task<IEnumerable<UserDto>> GetByRoleAsync(string role);
        Task<IEnumerable<UserDto>> SearchAsync(string searchTerm);
    }
} 