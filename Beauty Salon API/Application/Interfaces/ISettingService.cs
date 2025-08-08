using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISettingService
    {
        Task<IEnumerable<Setting>> GetAllAsync();
        Task<Setting> GetByKeyAsync(string key);
        Task<Setting> AddAsync(Setting setting);
        Task<Setting> UpdateAsync(Setting setting);
        Task<bool> DeleteAsync(string key);
    }
} 