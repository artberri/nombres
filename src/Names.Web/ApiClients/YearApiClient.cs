using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Names.Domain.Entities;

namespace Names.Web.ApiClients
{
    public class YearApiClient
    {
        const string ApiBase = "api/years";

        private readonly HttpClient _http;

        public YearApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<Year[]> GetAll()
        {
            return await _http.GetJsonAsync<Year[]>($"{Config.BaseUrl}/{ApiBase}");
        }
    }
}
