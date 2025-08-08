using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<RoleDto>> GetAllRoles()
        {
            return await _roleService.GetAllRolesAsync();
        }

        [HttpGet("user/{userId:long}")]
        public async Task<IEnumerable<string>> GetUserRoles(long userId)
        {
            return await _roleService.GetUserRolesAsync(userId);
        }

        [HttpPost("add-user-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUserToRole([FromQuery] long userId, [FromQuery] string roleName)
        {
            var result = await _roleService.AddUserToRoleAsync(userId, roleName);
            if (!result) return BadRequest();
            return Ok();
        }

        [HttpPost("remove-user-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUserFromRole([FromQuery] long userId, [FromQuery] string roleName)
        {
            var result = await _roleService.RemoveUserFromRoleAsync(userId, roleName);
            if (!result) return BadRequest();
            return Ok();
        }
    }
} 