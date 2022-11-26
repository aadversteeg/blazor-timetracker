using Core.Infrastructure.BlazorApp.Client;
using Core.Application;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Core.Infrastructure.BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");


			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IProjectRepository, MockData.ProjectRepository>();
			builder.Services.AddSingleton<ITimeEntryRepository, MockData.TimeEntryRepository>();

			builder.Services.AddSingleton<Navigation>();
            builder.Services.AddScoped<ProgramServices>();

            builder.Services.AddMsalAuthentication(options =>
            {
                builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
                options.ProviderOptions.LoginMode = "redirect";
            });

            var host = builder.Build();

            // make sure service is instantiated before navigation happens
            host.Services.GetRequiredService<Navigation>();
            await host.RunAsync();
        }
    }
}