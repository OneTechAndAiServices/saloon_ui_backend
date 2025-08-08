using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task<IEnumerable<string>> GetUserRolesAsync(long userId);
        Task<bool> AddUserToRoleAsync(long userId, string roleName);
        Task<bool> RemoveUserFromRoleAsync(long userId, string roleName);
    }
} 