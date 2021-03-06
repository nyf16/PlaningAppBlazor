using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlaningApp.Shared.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace PlaningApp.Client
{
    public class Program
    {
        private const string URL = "https://plannerappserver20200228091432.azurewebsites.net";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped<AuthenticationService>(s =>
            {
                return new AuthenticationService(URL);
            });
            builder.Services.AddScoped<PlansService>(s =>
            {
                return new PlansService(URL);
            });
            builder.Services.AddScoped<ToDoItemsService>(s =>
            {
                return new ToDoItemsService(URL);
            });

            builder.Services.AddFileReaderService(options =>
            {
                options.UseWasmSharedBuffer = true;
            });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();

            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
