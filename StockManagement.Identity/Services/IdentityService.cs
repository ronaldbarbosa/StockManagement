using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using StockManagement.Application.Interfaces.Services;
using StockManagement.Identity.Entities;

namespace StockManagement.Identity.Services
{
    public class IdentityService : IIdentityAppService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(SignInManager<User> signInManager, UserManager<User> userManager, IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        //public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
        //{
        //    try
        //    {
        //        var user = new User
        //        {
        //            UserName = request.Email,
        //            Email = request.Email,
        //            EmailConfirmed = true
        //        };

        //        var result = await _userManager.CreateAsync(user, request.Password);

        //        if (result.Succeeded) await _userManager.SetLockoutEnabledAsync(user, false);

        //        var response = new CreateUserResponse();

        //        if (!result.Succeeded)
        //        {
        //            response.StatusCode = HttpStatusCode.BadRequest;
        //        }
        //        else
        //        {
        //            response.StatusCode = HttpStatusCode.Created;
        //        }

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new CreateUserResponse()
        //        {
        //            StatusCode = HttpStatusCode.InternalServerError
        //        };
        //    }
        //}

        //public async Task<LoginResponse> Login(LoginRequest request)
        //{
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);
        //        var response = new LoginResponse();

        //        if (!result.Succeeded)
        //        {
        //            response.StatusCode = HttpStatusCode.Unauthorized;
        //        }
        //        else
        //        {
        //            var credentials = await GenerateCredentials(request.Email);
        //            response.AccessToken = credentials.AccessToken;
        //            response.RefreshToken = credentials.RefreshToken;
        //            response.StatusCode = HttpStatusCode.OK;
        //        }

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new LoginResponse()
        //        {
        //            StatusCode = HttpStatusCode.InternalServerError
        //        };
        //    }
        //}

        //private async Task<LoginResponse> GenerateCredentials(string email)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    var accessTokenClaims = await GetClaims(user!, true);
        //    var refreshTokenClaims = await GetClaims(user!, false);

        //    var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtOptions.AccessTokenExpiration);
        //    var refreshTokenExpiration = DateTime.Now.AddMinutes(_jwtOptions.RefreshTokenExpiration);

        //    var accessToken = GenerateToken(accessTokenClaims, accessTokenExpiration);
        //    var refreshToken = GenerateToken(refreshTokenClaims, refreshTokenExpiration);

        //    return new LoginResponse { 
        //        AccessToken = accessToken,
        //        RefreshToken = refreshToken,
        //    };
        //}

        //private string GenerateToken(IEnumerable<Claim> claims, DateTime expirationDate)
        //{
        //    var jwt = new JwtSecurityToken(
        //        issuer: _jwtOptions.Issuer,
        //        audience: _jwtOptions.Audience,
        //        claims: claims,
        //        expires: expirationDate,
        //        signingCredentials: _jwtOptions.SigningCredentials
        //        );

        //    return new JwtSecurityTokenHandler().WriteToken(jwt);
        //}

        //private async Task<IList<Claim>> GetClaims(User user, bool getUserClaims)
        //{
        //    var claims = new List<Claim>();

        //    claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
        //    claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email!));

        //    if (getUserClaims)
        //    {
        //        var userClaims = await _userManager.GetClaimsAsync(user);
        //        var roles = await _userManager.GetRolesAsync(user);

        //        claims.AddRange(userClaims);

        //        foreach (var role in roles)
        //        {
        //            claims.Add(new Claim("role", role));
        //        }
        //    }

        //    return claims;
        //}
    }
}
