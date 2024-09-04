using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using StockManagement.Application.DTOs.Request;
using StockManagement.Application.DTOs.Response;
using StockManagement.Application.Interfaces.Services;
using StockManagement.Domain.Entities.Responses;
using StockManagement.Identity.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace StockManagement.Identity.Services
{
    public class IdentityService : IIdentityService
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

        public async Task<Response<CreateUserResponse>?> CreateUser(CreateUserRequest request)
        {
            try
            {
                var user = new User
                {
                    UserName = request.Email,
                    Email = request.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded) await _userManager.SetLockoutEnabledAsync(user, false);

                var response = new Response<CreateUserResponse>(new CreateUserResponse() { Succeded = result.Succeeded });

                if (!result.Succeeded)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = ResponseMessages.RequestError;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.Created;
                    response.Message = ResponseMessages.Created;
                }

                return response;
            }
            catch (Exception ex)
            {
                return new Response<CreateUserResponse>(
                    new CreateUserResponse() { Succeded = false },
                    ResponseMessages.ServerError,
                    HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Response<LoginResponse>?> Login(LoginRequest request)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);
                var response = new Response<LoginResponse>(new LoginResponse() { });

                if (!result.Succeeded)
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.Unauthorized;

                    if (result.IsLockedOut)
                    {
                        response.Message = "Conta bloqueada.";
                    }
                    else if (result.IsNotAllowed)
                    {
                        response.Message = ResponseMessages.Unauthorized;
                    }
                    else
                    {
                        response.Message = "Usuário ou senha inválido(s).";
                    }
                }
                else
                {
                    response.Data = await GenerateCredentials(request.Email);
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Login realizado com suacesso.";
                }

                return response;
            }
            catch (Exception ex)
            {
                return new Response<LoginResponse>(
                    null,
                    ResponseMessages.ServerError,
                    HttpStatusCode.InternalServerError);
            }
        }

        private async Task<LoginResponse> GenerateCredentials(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var accessTokenClaims = await GetClaims(user!, true);
            var refreshTokenClaims = await GetClaims(user!, false);

            var accessTokenExpiration = DateTime.Now.AddMinutes(_jwtOptions.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_jwtOptions.RefreshTokenExpiration);

            var accessToken = GenerateToken(accessTokenClaims, accessTokenExpiration);
            var refreshToken = GenerateToken(refreshTokenClaims, refreshTokenExpiration);

            return new LoginResponse { 
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }

        private string GenerateToken(IEnumerable<Claim> claims, DateTime expirationDate)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: expirationDate,
                signingCredentials: _jwtOptions.SigningCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private async Task<IList<Claim>> GetClaims(User user, bool getUserClaims)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email!));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            if (getUserClaims)
            {
                var userClaims = await _userManager.GetClaimsAsync(user);
                var roles = await _userManager.GetRolesAsync(user);

                claims.AddRange(userClaims);

                foreach (var role in roles)
                {
                    claims.Add(new Claim("role", role));
                }
            }

            return claims;
        }
    }
}
