using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.DTOs;
using StockManagement.Identity.Entities;
using System.Data;
using System.Security.Claims;

namespace StockManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IdentityController(SignInManager<User> signInManager, UserManager<User> userManager) : ControllerBase
    {
        [HttpPost]        
        [Route("/logout")]
        public async Task<IResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        }

        [HttpGet]        
        [Route("/roles")]
        public async Task<IResult> Roles()
        {
            var user = HttpContext.User;

            if (user.Identity is null || !user.Identity.IsAuthenticated)
                return Results.Unauthorized();

            var identity = (ClaimsIdentity)user.Identity;
            var roles = identity
                .FindAll(identity.RoleClaimType)
                .Select(c => new RoleClaimDTO
                {
                    Issuer = c.Issuer,
                    OriginalIssuer = c.OriginalIssuer,
                    Type = c.Type,
                    Value = c.Value,
                    ValueType = c.ValueType
                });
            return await Task.FromResult<IResult>(TypedResults.Json(roles));
        }

        [HttpGet]
        [Route("/user/info")]
        public async Task<IResult> UserInfo()
        {
            var user = HttpContext.User;

            if (user.Identity is null || !user.Identity.IsAuthenticated)
                return Results.Unauthorized();

            var userInfo = await userManager.GetUserAsync(user);
            UserDTO userInfoDTO = new UserDTO() 
            { 
                Email = userInfo!.Email ?? "",
                EmailConfirmed = userInfo.EmailConfirmed,
                Name = userInfo.Name,
                Username = userInfo.UserName ?? "",
                PhoneNumber = userInfo.PhoneNumber ?? "",
                PhoneNumberConfirmed = userInfo.PhoneNumberConfirmed,
                TwoFactorEnabled = userInfo.TwoFactorEnabled,
                AvatarUrl = userInfo.AvatarUrl
            };
            return await Task.FromResult<IResult>(TypedResults.Json(userInfoDTO));
        }
    }
}
