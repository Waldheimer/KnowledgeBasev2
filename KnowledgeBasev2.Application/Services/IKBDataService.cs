using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;

namespace KnowledgeBasev2.Application.Services
{
    public interface IKBDataService
    {
        //-----------------------------
        //--------- CREATE ------------
        //-----------------------------
        Task<ServiceResponse<Guid>> CreateAsync(CreateDTO command);
        //-----------------------------
        //--------- READ --------------
        //-----------------------------
        Task<IEnumerable<ReadUpdateDTO>> GetAsync();
        Task<ReadUpdateDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<ReadUpdateDTO>> GetBySystemAsync(string system);
        Task<IEnumerable<ReadUpdateDTO>> GetByTechAsync(string tech);
        Task<IEnumerable<ReadUpdateDTO>> GetByLangAsync(string lang);
        //-----------------------------
        //--------- UPDATA ------------
        //-----------------------------
        Task<ServiceResponse<Guid>> UpdateAsync(ReadUpdateDTO command);
        //-----------------------------
        //--------- DELETE ------------
        //-----------------------------
        Task<ServiceResponse<Guid>> DeleteAsync(Guid id);
    }
}
