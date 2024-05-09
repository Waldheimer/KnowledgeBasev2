using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;

namespace KnowledgeBasev2.Application.Contracts
{
    public interface IKbDocumentation
    {
        //  C
        Task<ServiceResponse<Guid>> CreateAsync(CreateDTO docu);
        //  R
        Task<IEnumerable<ReadUpdateDTO>> GetAsync();
        Task<ReadUpdateDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<ReadUpdateDTO>> GetBySystemAsync(string system);
        Task<IEnumerable<ReadUpdateDTO>> GetByTechAsync(string tech);
        Task<IEnumerable<ReadUpdateDTO>> GetByLangAsync(string lang);
        //  U
        Task<ServiceResponse<Guid>> UpdateAsync(ReadUpdateDTO docu);
        //  D
        Task<ServiceResponse<Guid>> DeleteAsync(Guid id);
    }
}
