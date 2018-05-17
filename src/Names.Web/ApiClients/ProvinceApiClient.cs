using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Names.Domain.Entities;

namespace Names.Web.ApiClients
{
    public class ProvinceApiClient
    {
        const string ApiBase = "api/provinces";

        private readonly HttpClient _http;

        public ProvinceApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<Province[]> GetAll()
        {
            return await _http.GetJsonAsync<Province[]>($"{Config.BaseUrl}/{ApiBase}");
        }
    }
}
