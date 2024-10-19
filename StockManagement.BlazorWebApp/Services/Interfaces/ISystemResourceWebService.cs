using StockManagement.Application.DTOs.Response;

namespace StockManagement.BlazorWebApp.Services.Interfaces
{
    public interface ISystemResourceWebService
    {
        Task<SystemResourceResponse> GetAllResourcesAsync();
    }
}
