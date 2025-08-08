using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;
        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<AppointmentDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<AppointmentDto>> GetById(long id)
        {
            var appointment = await _service.GetByIdAsync(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }

        [HttpGet("status/{status}")]
        public async Task<IEnumerable<AppointmentDto>> GetByStatus(string status)
        {
            return await _service.GetByStatusAsync(status);
        }

        [HttpGet("date-range")]
        public async Task<IEnumerable<AppointmentDto>> GetByDateRange([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            return await _service.GetByDateRangeAsync(start, end);
        }

        [HttpGet("client/{clientId:long}")]
        public async Task<IEnumerable<AppointmentDto>> GetByClient(long clientId)
        {
            return await _service.GetByClientAsync(clientId);
        }

        [HttpGet("worker/{workerId:long}")]
        public async Task<IEnumerable<AppointmentDto>> GetByWorker(long workerId)
        {
            return await _service.GetByWorkerAsync(workerId);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> Post([FromBody] AppointmentDto dto)
        {
            try
            {
                var created = await _service.AddAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<AppointmentDto>> Put([FromBody] AppointmentDto dto)
        {
            var updated = await _service.UpdateAsync(dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 