using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var entities = await _userRepository.GetAllAsync();
            return entities.Select(MapToDto);
        }

        public async Task<UserDto> GetByIdAsync(long id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task<UserDto> AddAsync(UserDto dto)
        {
            // Validation logic from AddWithValidationAsync
            var existing = await _userRepository.GetByEmailAsync(dto.Email);
            if (existing != null)
                throw new System.InvalidOperationException("Email already exists.");
            var entity = MapToEntity(dto);
            await _userRepository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<UserDto> UpdateAsync(UserDto dto)
        {
            var entity = MapToEntity(dto);
            await _userRepository.UpdateAsync(entity);
            return MapToDto(entity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null) return false;
            await _userRepository.DeleteAsync(entity);
            return true;
        }

        // Advanced queries
        public async Task<IEnumerable<UserDto>> GetByRoleAsync(string role)
        {
            var entities = await _userRepository.GetByRoleAsync(role);
            return entities.Select(MapToDto);
        }

        public async Task<IEnumerable<UserDto>> SearchAsync(string searchTerm)
        {
            var entities = await _userRepository.SearchAsync(searchTerm);
            return entities.Select(MapToDto);
        }

        // Validation/business logic
        // Mapping helpers
        private UserDto MapToDto(ApplicationUser entity)
        {
            var roles = _userManager.GetRolesAsync(entity).Result;
            return new UserDto
            {
                Id = entity.Id,
                Username = entity.UserName,
               
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Roles = roles.ToList(),
                Status = entity.Status
            };
        }
        private ApplicationUser MapToEntity(UserDto dto)
        {
            return new ApplicationUser
            {
                Id = dto.Id,
                UserName = dto.Username,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Status = dto.Status
            };
        }
    }
} 