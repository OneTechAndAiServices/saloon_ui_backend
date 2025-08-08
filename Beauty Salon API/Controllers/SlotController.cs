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
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _service;
        public SlotController(ISlotService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<SlotDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<SlotDto>> GetById(long id)
        {
            var slot = await _service.GetByIdAsync(id);
            if (slot == null) return NotFound();
            return Ok(slot);
        }

        [HttpGet("available/{workerId:long}")]
        public async Task<IEnumerable<SlotDto>> GetAvailableSlotsForWorker(long workerId, [FromQuery] DateTime date)
        {
            return await _service.GetAvailableSlotsForWorker(workerId, date);
        }

        [HttpGet("blocked/{workerId:long}")]
        public async Task<IEnumerable<SlotDto>> GetBlockedSlotsForWorker(long workerId)
        {
            return await _service.GetBlockedSlotsForWorker(workerId);
        }

        [HttpGet("week/{workerId:long}")]
        public async Task<IEnumerable<SlotDto>> GetSlotsForWorkerInWeek(long workerId, [FromQuery] DateTime weekStart)
        {
            return await _service.GetSlotsForWorkerInWeek(workerId, weekStart);
        }

        [HttpPost]
        public async Task<ActionResult<SlotDto>> Post([FromBody] SlotDto dto)
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
        public async Task<ActionResult<SlotDto>> Put([FromBody] SlotDto dto)
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