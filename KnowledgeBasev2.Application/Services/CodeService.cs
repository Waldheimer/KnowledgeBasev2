using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using System.Net.Http.Json;

namespace KnowledgeBasev2.Application.Services
{
    public class CodeService : IKBDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "https://localhost:7296";

        public CodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<Guid>> CreateAsync(CreateDTO code)
        {
            var data = await _httpClient.PostAsJsonAsync($"{BaseUrl}/api/code", code);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
            return response!;
        }

        public async Task<ServiceResponse<Guid>> DeleteAsync(Guid id)
        {
            var data = await _httpClient.DeleteAsync($"{BaseUrl}/api/code/{id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<IEnumerable<ReadUpdateDTO>>($"{BaseUrl}/api/code");
            return data!;
        }

        public async Task<ReadUpdateDTO> GetByIdAsync(Guid id)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/code/{id}");
            var response = await data.Content.ReadFromJsonAsync<ReadUpdateDTO>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetByLangAsync(string lang)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/code/lang/{lang}");
            var response = await data.Content.ReadFromJsonAsync<IEnumerable<ReadUpdateDTO>>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetBySystemAsync(string system)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/code/system/{system}");
            var response = await data.Content.ReadFromJsonAsync<IEnumerable<ReadUpdateDTO>>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetByTechAsync(string tech)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/code/tech/{tech}");
            var response = await data.Content.ReadFromJsonAsync<IEnumerable<ReadUpdateDTO>>();
            return response!;
        }

        public async Task<ServiceResponse<Guid>> UpdateAsync(ReadUpdateDTO command)
        {
            var data = await _httpClient.PutAsJsonAsync($"{BaseUrl}/api/code", command);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
            return response!;
        }

    }
}
