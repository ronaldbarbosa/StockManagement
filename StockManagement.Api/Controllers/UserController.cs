using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;
using StockManagement.Application.Interfaces.Services;
using StockManagement.Core.Entities;
using StockManagement.Core.Entities.Responses;
using System.Net;

namespace StockManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IIdentityService identityService) : ControllerBase
    {
        private IIdentityService _identityService = identityService;

        [HttpPost("cadastro")]
        public async Task<Response<CreateUserResponse>> Create(CreateUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new Response<CreateUserResponse>(null, ResponseMessages.RequestError, HttpStatusCode.BadRequest);
            }

            return await _identityService.CreateUser(request);
        }

        [HttpPost("login")]
        public async Task<Response<LoginResponse>> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new Response<LoginResponse>(null, ResponseMessages.RequestError, HttpStatusCode.BadRequest);
            }

            return await _identityService.Login(request);
        }
    }
}
