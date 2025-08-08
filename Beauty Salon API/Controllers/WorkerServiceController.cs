using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkerServiceController : ControllerBase
    {
        private readonly IWorkerServiceService _service;
        public WorkerServiceController(IWorkerServiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkerServiceDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{workerId:long}/{serviceId:long}")]
        public async Task<ActionResult<WorkerServiceDto>> GetById(long workerId, long serviceId)
        {
            var ws = await _service.GetByIdAsync(workerId, serviceId);
            if (ws == null) return NotFound();
            return Ok(ws);
        }

        [HttpPost]
        public async Task<ActionResult<WorkerServiceDto>> Post([FromBody] WorkerServiceDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { workerId = created.WorkerId, serviceId = created.ServiceId }, created);
        }

        [HttpDelete("{workerId:long}/{serviceId:long}")]
        public async Task<IActionResult> Delete(long workerId, long serviceId)
        {
            var deleted = await _service.DeleteAsync(workerId, serviceId);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 