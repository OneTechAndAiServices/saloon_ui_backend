using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IEnumerable<BlogDto>> GetAll()
        {
            return await _blogService.GetAllAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<BlogDto>> GetById(long id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult<BlogDto>> Post([FromBody] BlogDto dto)
        {
            var created = await _blogService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<ActionResult<BlogDto>> Put([FromBody] BlogDto dto)
        {
            var updated = await _blogService.UpdateAsync(dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _blogService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 