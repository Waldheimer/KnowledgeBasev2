using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using System.Net.Http.Json;

namespace KnowledgeBasev2.Application.Services
{
    public class CommandService : IKBDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "https://localhost:7296";

        public CommandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<Guid>> CreateAsync(CreateDTO command)
        {
            var data = await _httpClient.PostAsJsonAsync($"{BaseUrl}/api/command", command);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
            return response!;
        }

        public async Task<ServiceResponse<Guid>> DeleteAsync(Guid id)
        {
            var data = await _httpClient.DeleteAsync($"{BaseUrl}/api/command/{id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<IEnumerable<ReadUpdateDTO>>($"{BaseUrl}/api/command");
            return data!;
        }

        public async Task<ReadUpdateDTO> GetByIdAsync(Guid id)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/command/{id}");
            var response = await data.Content.ReadFromJsonAsync<ReadUpdateDTO>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetByLangAsync(string lang)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/commands/lang/{lang}");
            var response = await data.Content.ReadFromJsonAsync<IEnumerable<ReadUpdateDTO>>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetBySystemAsync(string system)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/commands/system/{system}");
            var response = await data.Content.ReadFromJsonAsync<IEnumerable<ReadUpdateDTO>>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetByTechAsync(string tech)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/commands/tech/{tech}");
            var response = await data.Content.ReadFromJsonAsync<IEnumerable<ReadUpdateDTO>>();
            return response!;
        }

        public async Task<ServiceResponse<Guid>> UpdateAsync(ReadUpdateDTO command)
        {
            var data = await _httpClient.PutAsJsonAsync($"{BaseUrl}/api/commands", command);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
            return response!;
        }
    }
}
