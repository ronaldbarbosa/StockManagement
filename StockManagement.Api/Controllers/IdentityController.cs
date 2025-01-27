using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.DTOs;
using StockManagement.Identity.Entities;
using System.Security.Claims;

namespace StockManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IdentityController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager) : ControllerBase
    {
        [HttpPost]        
        [Route("/logout")]
        public async Task<IResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        }

        [HttpGet]        
        [Route("/user/roles")]
        public async Task<IResult> UserRoles()
        {
            var user = HttpContext.User;

            if (user.Identity is null || !user.Identity.IsAuthenticated)
                return Results.Unauthorized();

            var identity = (ClaimsIdentity)user.Identity;
            var roles = identity
                .FindAll(identity.RoleClaimType)
                .Select(c => new UserRoleDTO
                {
                    Issuer = c.Issuer,
                    OriginalIssuer = c.OriginalIssuer,
                    Type = c.Type,
                    Value = c.Value,
                    ValueType = c.ValueType
                });
            return await Task.FromResult<IResult>(TypedResults.Json(roles));
        }

        [HttpPost]
        [Route("/roles")]
        public async Task<IResult> Roles(string role)
        {
            var result = await roleManager.CreateAsync(new Role(role));
            if (result.Succeeded) return Results.Created();
            return Results.Problem();
        }
        
        [HttpGet]
        [Route("/roles")]
        public async Task<IResult> Roles()
        {
            var roles = roleManager.Roles;
            return await Task.FromResult<IResult>(TypedResults.Json(roles));
        }   
        
        [HttpGet]
        [Route("/roles/total-users/{role}")]
        public async Task<IResult> TotalUsersRole(string role)
        {
            var roleEntity = await roleManager.FindByNameAsync(role);

            if (roleEntity is null) return Results.NotFound();

            var usersInRole = await userManager.GetUsersInRoleAsync(role);
            var totalUsers = usersInRole.Count;

            return Results.Ok(totalUsers);
        }
        

        [HttpGet]
        [Route("/claims/{role}")]
        public async Task<IResult> Claims(string role)
        {
            var roleEntity = await roleManager.FindByNameAsync(role);
            
            if (roleEntity is null) return Results.NotFound();
            
            var claims = await roleManager.GetClaimsAsync(roleEntity);
            
            return await Task.FromResult<IResult>(TypedResults.Json(claims));
        }

        [HttpPost]
        [Route("/claims/{role}")]
        public async Task<IResult> Claims(string role, string claim)
        {
            var roleEntity = await roleManager.FindByNameAsync(role);
            
            if (roleEntity is null) return Results.NotFound();

            var result = await roleManager.AddClaimAsync(roleEntity, new Claim("SystemResource", claim));

            if (result.Succeeded) return Results.Created();

            return Results.Problem();
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

        [HttpPost]
        [Route("/user/info")]
        public async Task<IResult> UpdateUserInfo(UserDTO userDTO)
        {
            var user = HttpContext.User;
            var userInfo = await userManager.GetUserAsync(user);

            if (userInfo is not null)
            {
                userInfo.UserName = userDTO.Username;
                userInfo.Email = userDTO.Email;
                userInfo.Name = userDTO.Name;
                userInfo.PhoneNumber = userDTO.PhoneNumber;
                userInfo.AvatarUrl = userDTO.AvatarUrl;

                var result = await userManager.UpdateAsync(userInfo);
                if (result.Succeeded) return await Task.FromResult<IResult>(TypedResults.Json(userDTO));
            }

            return Results.Problem();
        }
    }
}
