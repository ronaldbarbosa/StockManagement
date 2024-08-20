using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;
using StockManagement.Core.Entities.Responses;

namespace StockManagement.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<Response<CreateUserResponse>?> CreateUser(CreateUserRequest request);
        Task<Response<LoginResponse>?> Login(LoginRequest request);
    }
}
