using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;

namespace StockManagement.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<CreateUserResponse> CreateUser(CreateUserRequest request);
        Task<LoginResponse> Login(LoginRequest request);
    }
}
