using BlazorWasm.WebApp.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWasm.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddHttpClient<ICodeChangesService, CodeChangesService>(
                client => client.BaseAddress = new Uri(builder.Configuration["AzFunctionsUrls:GitHubCodeChangesUrl"]));

            await builder.Build().RunAsync();
        }
    }
}
