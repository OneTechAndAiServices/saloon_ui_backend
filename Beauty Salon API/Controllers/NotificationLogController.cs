using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationLogController : ControllerBase
    {
        private readonly INotificationLogService _service;
        public NotificationLogController(INotificationLogService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<NotificationLogDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<NotificationLogDto>> GetById(long id)
        {
            var log = await _service.GetByIdAsync(id);
            if (log == null) return NotFound();
            return Ok(log);
        }

        [HttpPost]
        public async Task<ActionResult<NotificationLogDto>> Post([FromBody] NotificationLogDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<ActionResult<NotificationLogDto>> Put([FromBody] NotificationLogDto dto)
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