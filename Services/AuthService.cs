using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using EndlessPath.Domain.ValueObjects;

namespace EndlessPath.Services
{
    public static class AuthService
    {
        public static AuthResponse? Auth;
        public static HttpClient HttpClient = new HttpClient();

        public static async Task<bool> LoginAsync(string username, string password)
        {
            var body = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("client_id", "EndlessPath"),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("scope", "openid profile EndlessPath"),
                new KeyValuePair<string, string>("client_secret", "secret")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/connect/token")
            {
                Content = new FormUrlEncodedContent(body)
            };

            var response = await HttpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
        public static async Task<bool> CreateAccountAsync(string username, string password)
        {
            var response = await HttpClient.PostAsJsonAsync($"https://localhost:5001/api/accounts?username={username}&password={password}", new
            {
            });
            if (response.IsSuccessStatusCode)
            {
                Auth = await response.Content.ReadFromJsonAsync<AuthResponse>();
            }
            return response.IsSuccessStatusCode;
        }
    }
}
