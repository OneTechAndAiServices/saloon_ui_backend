using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<IEnumerable<ApplicationUser>> GetByRoleAsync(string role);
        Task<IEnumerable<ApplicationUser>> SearchAsync(string searchTerm);
        Task<bool> ExistsByEmailAsync(string email);
        Task<ApplicationUser> GetByEmailAsync(string email);
    }
} 