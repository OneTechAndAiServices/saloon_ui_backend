using Application.DTOs;
using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BlogService : IBlogService
    {
        private static List<BlogDto> _blogs = new List<BlogDto>();
        private static long _nextId = 1;

        public async Task<IEnumerable<BlogDto>> GetAllAsync()
        {
            return await Task.FromResult(_blogs);
        }

        public async Task<BlogDto> GetByIdAsync(long id)
        {
            return await Task.FromResult(_blogs.FirstOrDefault(b => b.Id == id));
        }

        public async Task<BlogDto> AddAsync(BlogDto dto)
        {
            dto.Id = _nextId++;
            _blogs.Add(dto);
            return await Task.FromResult(dto);
        }

        public async Task<BlogDto> UpdateAsync(BlogDto dto)
        {
            var blog = _blogs.FirstOrDefault(b => b.Id == dto.Id);
            if (blog == null) return null;
            blog.Title = dto.Title;
            blog.Content = dto.Content;
            blog.Category = dto.Category;
            blog.Tags = dto.Tags;
            blog.ImageUrl = dto.ImageUrl;
            blog.SeoTitle = dto.SeoTitle;
            blog.SeoDescription = dto.SeoDescription;
            blog.PublishedAt = dto.PublishedAt;
            return await Task.FromResult(blog);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var blog = _blogs.FirstOrDefault(b => b.Id == id);
            if (blog == null) return false;
            _blogs.Remove(blog);
            return await Task.FromResult(true);
        }
    }
} 