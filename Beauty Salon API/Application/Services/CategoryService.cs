using Application.DTOs;
using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private static List<CategoryDto> _categories = new List<CategoryDto>();
        private static long _nextId = 1;

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await Task.FromResult(_categories);
        }

        public async Task<CategoryDto> GetByIdAsync(long id)
        {
            return await Task.FromResult(_categories.FirstOrDefault(c => c.Id == id));
        }

        public async Task<CategoryDto> AddAsync(CategoryDto dto)
        {
            dto.Id = _nextId++;
            _categories.Add(dto);
            return await Task.FromResult(dto);
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto dto)
        {
            var category = _categories.FirstOrDefault(c => c.Id == dto.Id);
            if (category == null) return null;
            category.Name = dto.Name;
            category.Description = dto.Description;
            return await Task.FromResult(category);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return false;
            _categories.Remove(category);
            return await Task.FromResult(true);
        }
    }
} 