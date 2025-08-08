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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceDto>> GetAll()
        {
            return await _serviceService.GetAllAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ServiceDto>> GetById(long id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service == null) return NotFound();
            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDto>> Post([FromBody] ServiceDto dto)
        {
            var created = await _serviceService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceDto>> Put([FromBody] ServiceDto dto)
        {
            var updated = await _serviceService.UpdateAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _serviceService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 