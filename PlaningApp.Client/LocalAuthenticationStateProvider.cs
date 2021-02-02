﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PlaningApp.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlaningApp.Client
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storageService;

        public LocalAuthenticationStateProvider(ILocalStorageService storageService)
        {
            _storageService = storageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _storageService.ContainKeyAsync("User"))
            {
                var userInfo = await _storageService.GetItemAsync<LocalUserInfo>("User");

                var claims = new[]
                {
                    new Claim("Email", userInfo.Email),
                    new Claim("FirstName",userInfo.FirstName),
                    new Claim("LastName",userInfo.LastName),
                    new Claim("AccessToken", userInfo.AccessToken),
                    new Claim(ClaimTypes.NameIdentifier,userInfo.Id)
                };

                var identity = new ClaimsIdentity(claims, "Bearer Token");
                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }

            return new AuthenticationState(new System.Security.Claims.ClaimsPrincipal());
        }

        public async Task LogoutAsync()
        {
            await _storageService.RemoveItemAsync("User");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}
