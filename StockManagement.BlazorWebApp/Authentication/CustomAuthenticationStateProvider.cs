﻿using Microsoft.AspNetCore.Components.Authorization;
using StockManagement.Application.DTOs;
using System.Net.Http.Json;
using System.Security.Claims;

namespace StockManagement.BlazorWebApp.Authentication
{
    public class CustomAuthenticationStateProvider(HttpClient httpClient) : AuthenticationStateProvider, ICustomAuthenticationStateProvider
    {
        private bool _isAuthenticated = false;
        private readonly HttpClient _client = httpClient;

        public async Task<bool> CheckAuthenticatedAsync()
        {
            await GetAuthenticationStateAsync();
            return _isAuthenticated;
        }

        public void NotifyAuthenticationStateChanged()
            => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            _isAuthenticated = false;
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            var userInfo = await GetUser();
            if (userInfo is null)
                return new AuthenticationState(user);

            var claims = await GetClaims(userInfo);

            var id = new ClaimsIdentity(claims, nameof(CustomAuthenticationStateProvider));
            user = new ClaimsPrincipal(id);
            _isAuthenticated = true;
            return new AuthenticationState(user);
        }

        private async Task<UserDTO?> GetUser()
        {
            try
            {
                return await _client.GetFromJsonAsync<UserDTO?>("manage/info");
            }
            catch
            {
                return null;
            }
        }

        private async Task<List<Claim>> GetClaims(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email)
            };

            UserDTO? userInfo;

            claims.AddRange(
                user.Claims.Where(x =>
                        x.Key != ClaimTypes.Name &&
                        x.Key != ClaimTypes.Email)
                    .Select(x
                        => new Claim(x.Key, x.Value))
            );

            UserRoleDTO[]? roles;
            try
            {
                roles = await _client.GetFromJsonAsync<UserRoleDTO[]>("user/roles");
                userInfo = await _client.GetFromJsonAsync<UserDTO>("user/info");

                if (userInfo is not null) claims.Add(new Claim(ClaimTypes.Name, userInfo.Name));
            }
            catch
            {
                return claims;
            }

            foreach (var role in roles ?? [])
                if (!string.IsNullOrEmpty(role.Type) && !string.IsNullOrEmpty(role.Value))
                    claims.Add(new Claim(role.Type, role.Value, role.ValueType, role.Issuer, role.OriginalIssuer));

            return claims;
        }
    }
}
