using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<ApplicationUser>> GetByRoleAsync(string role)
        {
            // Join AspNetUserRoles and AspNetRoles to get users by role
            var roleEntity = await _context.Roles.FirstOrDefaultAsync(r => r.Name == role);
            if (roleEntity == null) return new List<ApplicationUser>();
            var userIds = await _context.Set<IdentityUserRole<long>>()
                .Where(ur => ur.RoleId == roleEntity.Id)
                .Select(ur => ur.UserId)
                .ToListAsync();
            return await _context.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> SearchAsync(string searchTerm)
        {
            return await _context.Users
                .Where(u => u.UserName.Contains(searchTerm) || u.Email.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
} 