using System;
using Dalton.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dalton.Services
{
    public class MyApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;


        public MyApiService(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(_apiSettings.BaseUrl + url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> GetByIdAsync<T>(string url, long Id)
        {
            var response = await _httpClient.GetAsync(_apiSettings.BaseUrl + url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            var response = await _httpClient.PostAsJsonAsync(_apiSettings.BaseUrl + url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PutAsync<T>(string url, object data)
        {
            var response = await _httpClient.PutAsJsonAsync(_apiSettings.BaseUrl + url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(_apiSettings.BaseUrl + url);
            response.EnsureSuccessStatusCode();
        }
    }
}
