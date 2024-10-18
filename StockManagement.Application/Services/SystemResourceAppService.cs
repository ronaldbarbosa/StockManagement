using StockManagement.Application.DTOs;
using StockManagement.Application.Interfaces.Services;
using StockManagement.Domain.Interfaces.Services;

namespace StockManagement.Application.Services
{
    public class SystemResourceAppService(ISystemResourceService systemResourceService) : ISystemResourceAppService
    {
        private readonly ISystemResourceService _systemResourceService = systemResourceService;

        public async Task<List<SystemResourceDTO>> GetAllAsync()
        {
            var result = await _systemResourceService.GetAllAsync();
            var response = new List<SystemResourceDTO>();

            if (result is not null && result.Count > 0)
            {
                foreach (var resource in result)
                {
                    response.Add((SystemResourceDTO)resource);
                }
            }

            return response;
        }
    }
}
