using StockManagement.Application.DTOs;
using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;

namespace StockManagement.BlazorWebApp.Services.Interfaces
{
    public interface IUserWebService
    {
        #region Access
        Task<LoginResponse> SignInAsync(LoginRequest request);
        Task<CreateUserResponse> SignUpAsync(CreateUserRequest request);
        Task LogoutAsync();
        #endregion

        #region User
        Task<GetUserResponse> GetUserInfoAsync();
        Task<UpdateUserResponse> UpdateUserInfoAsync(UserDTO user);
        Task<UpdateUserAccessResponse> UpdateUserAccessAsync(UpdateUserAccessRequest user);
        #endregion

        #region Roles
        Task<GetRolesResponse> GetAllRolesAsync();
        Task<GetRolesResponse> GetRolesAsync(string userId);
        Task<CreateRoleResponse> CreateRoleAsync(string roleName);
        #endregion
    }
}
