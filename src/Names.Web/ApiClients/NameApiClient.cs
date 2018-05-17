using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Names.Web.Model;

namespace Names.Web.ApiClients
{
    public class NameApiClient
    {
        const string ApiBase = "api/names";

        private readonly HttpClient _http;

        public NameApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<TagName[]> GetAll()
        {
            return await _http.GetJsonAsync<TagName[]>($"{Config.BaseUrl}/{ApiBase}");
        }

        public async Task<TagName[]> GetByProvince(int provinceId)
        {
            return await _http.GetJsonAsync<TagName[]>($"{Config.BaseUrl}/{ApiBase}/byprovince/{provinceId.ToString()}");
        }

        public async Task<TagName[]> GetByYear(int yearId)
        {
            return await _http.GetJsonAsync<TagName[]>($"{Config.BaseUrl}/{ApiBase}/byyear/{yearId.ToString()}");
        }

        public async Task<TagName[]> GetByYearAndProvince(int provinceId, int yearId)
        {
            return await _http.GetJsonAsync<TagName[]>($"{Config.BaseUrl}/{ApiBase}/byprovince/{provinceId.ToString()}/byyear/{yearId.ToString()}");
        }
    }
}
