using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<UserDto>> GetById(long id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("role/{role}")]
        public async Task<IEnumerable<UserDto>> GetByRole(string role)
        {
            return await _userService.GetByRoleAsync(role);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<UserDto>> Search([FromQuery] string q)
        {
            return await _userService.SearchAsync(q);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto dto)
        {
            try
            {
                var created = await _userService.AddAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (System.InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> Put([FromBody] UserDto dto)
        {
            var updated = await _userService.UpdateAsync(dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _userService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 