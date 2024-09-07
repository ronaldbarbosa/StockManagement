using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;
using StockManagement.Application.Interfaces.Services;

namespace StockManagement.Api.Controllers
{
    [ApiController]
    [Route("api/usuario")]       
    public class UserController(IIdentityService identityService) : ControllerBase
    {
        private IIdentityService _identityService = identityService;

        [HttpPost("cadastro")]
        public async Task<CreateUserResponse> Create(CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new CreateUserResponse()
                {
                    Succeded = false,
                };
            }

            return await _identityService.CreateUser(request);
        }

        [HttpPost("login")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new LoginResponse();
            }

            return await _identityService.Login(request);
        }
    }
}
