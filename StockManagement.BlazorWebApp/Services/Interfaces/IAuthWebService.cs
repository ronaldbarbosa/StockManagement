using StockManagement.Application.DTOs;
using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;

namespace StockManagement.BlazorWebApp.Services.Interfaces
{
    public interface IAuthWebService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task LogoutAsync();
        Task<CreateUserResponse> RegisterAsync(CreateUserRequest request);
        Task<GetUserResponse> GetUserInfoAsync();
        Task<UpdateUserResponse> UpdateUserInfoAsync(UserDTO user);
        Task<UpdateUserAccessResponse> UpdateUserAccessAsync(UpdateUserAccessRequest user);
    }
}
