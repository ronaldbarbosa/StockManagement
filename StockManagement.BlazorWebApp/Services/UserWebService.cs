using StockManagement.Application.DTOs;
using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;
using StockManagement.BlazorWebApp.Services.Interfaces;
using StockManagement.Shared.IdentityEntities;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace StockManagement.BlazorWebApp.Services
{
    public class UserWebService(HttpClient httpClient) : IUserWebService
    {
        private readonly HttpClient _client = httpClient;

        private UserDTO? _userDTO;

        public async Task<GetUserResponse> GetUserInfoAsync()
        {
            var response = new GetUserResponse();

            if (_userDTO is null)
            {
                var result = await _client.GetAsync("user/info");


                if (result.IsSuccessStatusCode)
                {
                    response.User = await result.Content.ReadFromJsonAsync<UserDTO>();
                }
            }
            else
            {
                response.User = _userDTO;
            }

            return response;
        }

        public async Task<UpdateUserResponse> UpdateUserInfoAsync(UserDTO user)
        {
            var result = await _client.PostAsJsonAsync("user/info", user);
            var response = new UpdateUserResponse();

            if (result.IsSuccessStatusCode)
            {
                _userDTO = await result.Content.ReadFromJsonAsync<UserDTO>();
                response.User = _userDTO;
            }

            return response;
        }

        public async Task<LoginResponse> SignInAsync(LoginRequest request)
        {
            var result = await _client.PostAsJsonAsync("login?useCookies=true", request);

            if (result.IsSuccessStatusCode)
            {
                await GetUserInfoAsync();
                return new LoginResponse();
            }

            var errors = await result.Content.ReadFromJsonAsync<LoginResponse>();

            return errors?.Errors.Count > 0 ? errors : new LoginResponse()
            {
                StatusCode = HttpStatusCode.Unauthorized
            };
        }

        public async Task LogoutAsync()
        {
            var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
            await _client.PostAsJsonAsync("logout", emptyContent);
        }

        public async Task<CreateUserResponse> SignUpAsync(CreateUserRequest request)
        {
            var result = await _client.PostAsJsonAsync("register", request);

            if (result.IsSuccessStatusCode) return new CreateUserResponse();

            var errors = await result.Content.ReadFromJsonAsync<CreateUserResponse>();
            return errors ?? new CreateUserResponse();
        }

        public async Task<UpdateUserAccessResponse> UpdateUserAccessAsync(UpdateUserAccessRequest user)
        {
            var result = await _client.PostAsJsonAsync("manage/info", user);
            var response = new UpdateUserAccessResponse();

            if (result.IsSuccessStatusCode)
            {
                return response;
            }

            var errors = await result.Content.ReadFromJsonAsync<UpdateUserAccessResponse>();

            return errors ?? new UpdateUserAccessResponse();
        }

        public async Task<GetRolesResponse> GetAllRolesAsync()
        {
            var result = await _client.GetAsync("/roles");
            var response = new GetRolesResponse();

            if (result.IsSuccessStatusCode)
            {
                var roles = await result.Content.ReadFromJsonAsync<List<Role>>();

                foreach (var role in roles)
                {
                    var totalUsersResponse = await _client.GetAsync($"/roles/total-users/{role.Name}");
                    var roleDTO = new RoleDTO
                    {
                        Name = role.Name,
                        Id = role.Id,
                        NormalizedName = role.NormalizedName,
                        TotalUsers = totalUsersResponse.IsSuccessStatusCode ? await totalUsersResponse.Content.ReadFromJsonAsync<int>() : 0,
                        Claims = new List<ClaimDTO>()
                    };

                    var claimsResult = await _client.GetAsync($"/claims/{role.Name}");
                    if (claimsResult.IsSuccessStatusCode)
                    {
                        roleDTO.Claims = await claimsResult.Content.ReadFromJsonAsync<List<ClaimDTO>>();
                    }

                    response.Roles.Add(roleDTO);
                }
            }
            return response;
        }

        public Task<GetRolesResponse> GetRolesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateRoleResponse> CreateRoleAsync(string roleName)
        {
            var result = await _client.PostAsJsonAsync("roles", roleName);
            var response = new CreateRoleResponse();

            if (!result.IsSuccessStatusCode)
            {
                result.StatusCode = result.StatusCode;
            }
            
            return response;
        }
    }
}
