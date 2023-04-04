using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumeService1.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly HttpClient _httpClient;

        public EncryptionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> DecryptDataAsync(string text, string key)
        {
            try
            {
                var encryptionData = new EncryptionData { Text = text, Key = key };
                var json = JsonSerializer.Serialize(encryptionData);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost:5172/encryption/decrypt", data);
                var result = await response.Content.ReadAsStringAsync(); 
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while decrypting the data: {ex.Message}");
                throw;
            }
        }
        public async Task<string> EncryptDataAsync(string text, string key)
        {
            try
            {
                var encryptionData = new EncryptionData { Text = text, Key = key };
                var json = JsonSerializer.Serialize(encryptionData);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost:5172/encryption/encrypt", data);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while Encrypting the data: {ex.Message}");
                throw;
            }
        }
    }
}
