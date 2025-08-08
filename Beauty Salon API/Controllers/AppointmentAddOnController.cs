using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentAddOnController : ControllerBase
    {
        private readonly IAppointmentAddOnService _service;
        public AppointmentAddOnController(IAppointmentAddOnService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<AppointmentAddOnDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{appointmentId:long}/{addOnId:long}")]
        public async Task<ActionResult<AppointmentAddOnDto>> GetById(long appointmentId, long addOnId)
        {
            var aa = await _service.GetByIdAsync(appointmentId, addOnId);
            if (aa == null) return NotFound();
            return Ok(aa);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentAddOnDto>> Post([FromBody] AppointmentAddOnDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { appointmentId = created.AppointmentId, addOnId = created.AddOnId }, created);
        }

        [HttpDelete("{appointmentId:long}/{addOnId:long}")]
        public async Task<IActionResult> Delete(long appointmentId, long addOnId)
        {
            var deleted = await _service.DeleteAsync(appointmentId, addOnId);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 