using Domain.Entities;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettingController : ControllerBase
    {
        private readonly ISettingService _service;
        public SettingController(ISettingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Setting>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<Setting>> GetByKey(string key)
        {
            var setting = await _service.GetByKeyAsync(key);
            if (setting == null) return NotFound();
            return Ok(setting);
        }

        [HttpPost]
        public async Task<ActionResult<Setting>> Post([FromBody] Setting setting)
        {
            var created = await _service.AddAsync(setting);
            return CreatedAtAction(nameof(GetByKey), new { key = created.Key }, created);
        }

        [HttpPut]
        public async Task<ActionResult<Setting>> Put([FromBody] Setting setting)
        {
            var updated = await _service.UpdateAsync(setting);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            var deleted = await _service.DeleteAsync(key);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 