using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;

namespace StockManagement.Application.Interfaces.Services
{
    public interface IIdentityAppService
    {
        Task<CreateUserResponse> CreateUser(CreateUserRequest request);
        Task<LoginResponse> Login(LoginRequest request);
    }
}
