using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            return await _clientService.GetAllAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ClientDto>> GetById(long id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> Post([FromBody] ClientDto dto)
        {
            var created = await _clientService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<ActionResult<ClientDto>> Put([FromBody] ClientDto dto)
        {
            var updated = await _clientService.UpdateAsync(dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _clientService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 