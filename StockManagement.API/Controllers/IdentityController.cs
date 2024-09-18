using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Identity.Entities;

namespace StockManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(SignInManager<User> manager) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("/logout")]
        public async Task<IResult> Logout()
        {
            await manager.SignOutAsync();
            return Results.Ok();
        }
    }
}
