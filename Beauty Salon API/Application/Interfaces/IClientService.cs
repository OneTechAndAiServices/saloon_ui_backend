using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<ClientDto> GetByIdAsync(long id);
        Task<ClientDto> AddAsync(ClientDto dto);
        Task<ClientDto> UpdateAsync(ClientDto dto);
        Task<bool> DeleteAsync(long id);
    }
} 