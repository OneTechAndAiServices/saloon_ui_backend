using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceAddOnController : ControllerBase
    {
        private readonly IServiceAddOnService _service;
        public ServiceAddOnController(IServiceAddOnService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceAddOnDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{serviceId:long}/{addOnId:long}")]
        public async Task<ActionResult<ServiceAddOnDto>> GetById(long serviceId, long addOnId)
        {
            var sa = await _service.GetByIdAsync(serviceId, addOnId);
            if (sa == null) return NotFound();
            return Ok(sa);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceAddOnDto>> Post([FromBody] ServiceAddOnDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { serviceId = created.ServiceId, addOnId = created.AddOnId }, created);
        }

        [HttpDelete("{serviceId:long}/{addOnId:long}")]
        public async Task<IActionResult> Delete(long serviceId, long addOnId)
        {
            var deleted = await _service.DeleteAsync(serviceId, addOnId);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 