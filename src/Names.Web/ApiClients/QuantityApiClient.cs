using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Names.Domain.Entities;

namespace Names.Web.ApiClients
{
    public class QuantityApiClient
    {
        const string ApiBase = "api/quantities";

        private readonly HttpClient _http;

        public QuantityApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<Quantity[]> GetByName(int nameId)
        {
            return await _http.GetJsonAsync<Quantity[]>($"{Config.BaseUrl}/{ApiBase}/{nameId}");
        }

        public async Task<Quantity[]> GetByNameAndProvince(int nameId, int provinceId)
        {
            return await _http.GetJsonAsync<Quantity[]>($"{Config.BaseUrl}/{ApiBase}/{nameId}/byprovince/{provinceId}");
        }
    }
}
