using StockManagement.Application.DTOs.Request;
using StockManagement.BlazorWebApp.Services.Interfaces;
using System.Net.Http.Json;
using System.Text;

namespace StockManagement.BlazorWebApp.Services
{
    public class AuthWebService(IHttpClientFactory clientFactory) : IAuthWebService
    {
        private readonly HttpClient _client = clientFactory.CreateClient("client");

        public async Task<string> LoginAsync(LoginRequest request)
        {
            var result = await _client.PostAsJsonAsync("login?useCookies=true", request);
            return result.IsSuccessStatusCode
                ? "Login realizado com sucesso!"
                : "Não foi possível realizar o login";
        }

        public async Task LogoutAsync()
        {
            var emptyContent = new StringContent("{}", Encoding.UTF8, "application/json");
            await _client.PostAsJsonAsync("logout", emptyContent);
        }

        public async Task<string> RegisterAsync(CreateUserRequest request)
        {
            var result = await _client.PostAsJsonAsync("register", request);
            return result.IsSuccessStatusCode
                ? "Cadastro realizado com sucesso!"
                : "Não foi possível realizar o cadastro";
        }
    }
}
