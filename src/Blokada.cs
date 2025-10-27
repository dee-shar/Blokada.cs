using System;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Headers;

namespace BlokadaApi
{
    public class Blokada
    {
        private string accountId;
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://api.blocka.net/v2";
        public Blokada()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("blokada/23.1.10 (android-28 six release x86_64 blackshark gracelte touch api compatible)");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<string> GetAccount()
        {
            var response = await httpClient.PostAsync($"{apiUrl}/account", null);
            var content = await response.Content.ReadAsStringAsync();
            using var document = JsonDocument.Parse(content);
            if (document.RootElement.TryGetProperty("account", out var dataElement) && dataElement.TryGetProperty("id", out var idElement))
            {
                string accountId = idElement.GetString();
            }
            return content;
        }
        public async Task<string> GetDevices()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/device?account_id={accountId}");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetStats()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/stats?account_id={accountId}");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetActivity()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/activity?account_id={accountId}");
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetLease()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/lease?account_id={accountId}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
