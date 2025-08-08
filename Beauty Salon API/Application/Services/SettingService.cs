using Domain.Entities;
using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SettingService : ISettingService
    {
        private static List<Setting> _settings = new List<Setting>();

        public async Task<IEnumerable<Setting>> GetAllAsync()
        {
            return await Task.FromResult(_settings);
        }

        public async Task<Setting> GetByKeyAsync(string key)
        {
            return await Task.FromResult(_settings.FirstOrDefault(s => s.Key == key));
        }

        public async Task<Setting> AddAsync(Setting setting)
        {
            _settings.Add(setting);
            return await Task.FromResult(setting);
        }

        public async Task<Setting> UpdateAsync(Setting setting)
        {
            var s = _settings.FirstOrDefault(x => x.Key == setting.Key);
            if (s == null) return null;
            s.Value = setting.Value;
            return await Task.FromResult(s);
        }

        public async Task<bool> DeleteAsync(string key)
        {
            var s = _settings.FirstOrDefault(x => x.Key == key);
            if (s == null) return false;
            _settings.Remove(s);
            return await Task.FromResult(true);
        }
    }
} 