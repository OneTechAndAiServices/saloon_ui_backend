using Application.DTOs;
using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private static List<ClientDto> _clients = new List<ClientDto>();
        private static long _nextId = 1;

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            return await Task.FromResult(_clients);
        }

        public async Task<ClientDto> GetByIdAsync(long id)
        {
            return await Task.FromResult(_clients.FirstOrDefault(c => c.Id == id));
        }

        public async Task<ClientDto> AddAsync(ClientDto dto)
        {
            dto.Id = _nextId++;
            _clients.Add(dto);
            return await Task.FromResult(dto);
        }

        public async Task<ClientDto> UpdateAsync(ClientDto dto)
        {
            var client = _clients.FirstOrDefault(c => c.Id == dto.Id);
            if (client == null) return null;
            client.UserId = dto.UserId;
            client.FirstName = dto.FirstName;
            client.LastName = dto.LastName;
            client.Notes = dto.Notes;
            client.LoyaltyPoints = dto.LoyaltyPoints;
            return await Task.FromResult(client);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var client = _clients.FirstOrDefault(c => c.Id == id);
            if (client == null) return false;
            _clients.Remove(client);
            return await Task.FromResult(true);
        }
    }
} 