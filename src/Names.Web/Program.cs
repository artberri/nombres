using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
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
                services.AddSingleton<ProvinceChangeHandler>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
