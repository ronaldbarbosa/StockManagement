using StockManagement.Application.DTOs;

namespace StockManagement.Application.Interfaces.Services
{
    public interface ISystemResourceAppService
    {
        Task<List<SystemResourceDTO>> GetAllAsync();
    }
}
