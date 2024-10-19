using StockManagement.Application.DTOs;
using StockManagement.Application.DTOs.Response;
using StockManagement.BlazorWebApp.Services.Interfaces;
using System.Net;
using System.Net.Http.Json;

namespace StockManagement.BlazorWebApp.Services
{
    public class SystemResourceWebService(IHttpClientFactory clientFactory) : ISystemResourceWebService
    {
        private readonly HttpClient _client = clientFactory.CreateClient("client");

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
