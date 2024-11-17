using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Interfaces.Services;

namespace StockManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SystemResourceController(ISystemResourceAppService systemResourceAppService) : ControllerBase
    {
        private readonly ISystemResourceAppService _systemResourceAppService = systemResourceAppService;

        [HttpGet]
        public async Task<IResult> GetAllAsync()
        {
            try
            {
                var result = await _systemResourceAppService.GetAllAsync();
                return await Task.FromResult<IResult>(TypedResults.Json(result));
            }
            catch
            {
                return Results.Problem();
            }
        }
    }
}
