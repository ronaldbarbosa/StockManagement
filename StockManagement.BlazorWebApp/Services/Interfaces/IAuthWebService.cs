using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;

namespace StockManagement.BlazorWebApp.Services.Interfaces
{
    public interface IAuthWebService
    {
        Task<string> LoginAsync(LoginRequest request);
        Task LogoutAsync();
        Task<string> RegisterAsync(CreateUserRequest request);
    }
}
