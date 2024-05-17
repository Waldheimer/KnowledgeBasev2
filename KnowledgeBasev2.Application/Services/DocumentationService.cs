using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using System.Net.Http.Json;

namespace KnowledgeBasev2.Application.Services
{
    public class DocumentationService : IKBDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "https://localhost:7296";

        public DocumentationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<Guid>> CreateAsync(CreateDTO docu)
        {
            var data = await _httpClient.PostAsJsonAsync($"{BaseUrl}/api/documentation", docu);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
            return response!;
        }

        public async Task<ServiceResponse<Guid>> DeleteAsync(Guid id)
        {
            var data = await _httpClient.DeleteAsync($"{BaseUrl}/api/documentation/{id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<IEnumerable<ReadUpdateDTO>>($"{BaseUrl}/api/documentation");
            return data!;
        }

        public async Task<ReadUpdateDTO> GetByIdAsync(Guid id)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/documentation/{id}");
            var response = await data.Content.ReadFromJsonAsync<ReadUpdateDTO>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetByLangAsync(string lang)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/documentation/lang/{lang}");
            var response = await data.Content.ReadFromJsonAsync<IEnumerable<ReadUpdateDTO>>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetBySystemAsync(string system)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/documentation/system/{system}");
            var response = await data.Content.ReadFromJsonAsync<IEnumerable<ReadUpdateDTO>>();
            return response!;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> GetByTechAsync(string tech)
        {
            var data = await _httpClient.GetAsync($"{BaseUrl}/api/documentation/tech/{tech}");
            var response = await data.Content.ReadFromJsonAsync<IEnumerable<ReadUpdateDTO>>();
            return response!;
        }

        public async Task<ServiceResponse<Guid>> UpdateAsync(ReadUpdateDTO docu)
        {
            var data = await _httpClient.PutAsJsonAsync($"{BaseUrl}/api/documentation", docu);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse<Guid>>();
            return response!;
        }
    }
}
