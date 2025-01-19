using StockManagement.Application.DTOs;
using StockManagement.Application.DTOs.Response;
using StockManagement.BlazorWebApp.Services.Interfaces;
using System.Net;
using System.Net.Http.Json;

namespace StockManagement.BlazorWebApp.Services
{
    public class SystemResourceWebService(HttpClient httpClient) : ISystemResourceWebService
    {
        private readonly HttpClient _client = httpClient;

        public async Task<SystemResourceResponse> GetAllResourcesAsync()
        {
            var response = new SystemResourceResponse();

            var result = await _client.GetAsync("api/systemresource");

            if (result is not null && result.IsSuccessStatusCode)
            {
                response.StatusCode = result.StatusCode;
                response.Menu = await result.Content.ReadFromJsonAsync<List<SystemResourceDTO>>();
            }
            else
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
