using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;
using StockManagement.BlazorWebApp.Services.Interfaces;
using System.Net.Http.Json;
using System.Text;

namespace StockManagement.BlazorWebApp.Services
{
    public class AuthWebService(IHttpClientFactory clientFactory) : IAuthWebService
    {
        private readonly HttpClient _client = clientFactory.CreateClient("client");

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var result = await _client.PostAsJsonAsync("login?useCookies=true", request);

            if (result.IsSuccessStatusCode) return new LoginResponse();

            var errors = await result.Content.ReadFromJsonAsync<LoginResponse>();

            return errors?.Errors.Count > 0 ? errors : new LoginResponse()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized
            };
        }

        public async Task LogoutAsync()
        {
            var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
            await _client.PostAsJsonAsync("logout", emptyContent);
        }

        public async Task<CreateUserResponse> RegisterAsync(CreateUserRequest request)
        {
            var result = await _client.PostAsJsonAsync("register", request);
            
            if (result.IsSuccessStatusCode) return new CreateUserResponse();

            var errors = await result.Content.ReadFromJsonAsync<CreateUserResponse>();
            return errors ?? new CreateUserResponse();
        }
    }
}
