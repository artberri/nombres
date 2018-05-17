using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using Names.Web.ApiClients;
using Names.Web.EventHandlers;
using System;

namespace Names.Web
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                services.AddTransient<NameApiClient>();
                services.AddTransient<YearApiClient>();
                services.AddTransient<ProvinceApiClient>();
                services.AddTransient<QuantityApiClient>();
                services.AddSingleton<ProvinceChangeHandler>();
                services.AddSingleton<YearChangeHandler>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
