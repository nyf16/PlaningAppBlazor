using AKSoftware.WebApi.Client;
using PlaningApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaningApp.Shared.Services
{
    public class AuthenticationService
    {
        private readonly string _baseUrl;

        ServiceClient client = new ServiceClient();

        public AuthenticationService(string url)
        {
            _baseUrl = url;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterRequest request)
        {
            var response = await client.PostAsync<UserManagerResponse>($"{_baseUrl}/api/auth/register", request);
            return response.Result;
        }
    }
}
