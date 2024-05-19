using System.Net.Http.Json;

namespace KnowledgeBasev2.Application.Services
{
    public class DefaultInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "https://localhost:7296";

        public DefaultInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<string>> GetAllSystems()
        {
            var data = await _httpClient.GetFromJsonAsync<IEnumerable<string>>($"{BaseUrl}/api/info/systems");
            return data!;
        }
        public async Task<IEnumerable<string>> GetAllSTechs()
        {
            var data = await _httpClient.GetFromJsonAsync<IEnumerable<string>>($"{BaseUrl}/api/info/techs");
            return data!;
        }
        public async Task<IEnumerable<string>> GetAllLangs()
        {
            var data = await _httpClient.GetFromJsonAsync<IEnumerable<string>>($"{BaseUrl}/api/info/langs");
            return data!;
        }
    }
}
