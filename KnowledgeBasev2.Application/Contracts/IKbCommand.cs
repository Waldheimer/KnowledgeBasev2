using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;

namespace KnowledgeBasev2.Application.Contracts
{
    public interface IKbCommand
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


        //-----------------------------
        //--------- Validation --------
        //-----------------------------
        public Task<bool> IsUniqueCommand(CreateDTO command);
        public Task<bool> HasRequiredData(CreateDTO command);
        public Task<bool> HasValidExistingId(ReadUpdateDTO command);
        public Task<bool> IsExistingId(Guid id);
    }

}