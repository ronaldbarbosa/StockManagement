using StockManagement.Application.DTOs.Request;
using StockManagement.BlazorWebApp.Services.Interfaces;
using System.Net.Http.Json;

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

        public Task<string> RegisterAsync(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
