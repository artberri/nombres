using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Names.Web.ApiClients;
using Names.Web.EventHandlers;

namespace Names.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<NameApiClient>();
            services.AddTransient<YearApiClient>();
            services.AddTransient<ProvinceApiClient>();
            services.AddTransient<QuantityApiClient>();
            services.AddTransient<MixedApiClient>();
            services.AddSingleton<ProvinceChangeHandler>();
            services.AddSingleton<YearChangeHandler>();
            services.AddSingleton<QuantityTypeChangeHandler>();
            services.AddSingleton<ChartStatusHandler>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}