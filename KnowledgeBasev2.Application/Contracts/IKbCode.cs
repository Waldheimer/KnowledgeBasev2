﻿using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;

namespace KnowledgeBasev2.Application.Contracts
{
    public interface IKbCode
    {
        //-----------------------------
        //--------- CREATE ------------
        //-----------------------------
        Task<ServiceResponse<Guid>> CreateAsync(CreateDTO code);
        //-----------------------------
        //--------- READ --------------
        //-----------------------------
        Task<IEnumerable<ReadUpdateDTO>> GetAsync();
        Task<ReadUpdateDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<ReadUpdateDTO>> GetBySystemAsync(string system);
        Task<IEnumerable<ReadUpdateDTO>> GetByTechAsync(string tech);
        Task<IEnumerable<ReadUpdateDTO>> GetByLangAsync(string lang);
        //-----------------------------
        //--------- UPDATE ------------
        //-----------------------------
        Task<ServiceResponse<Guid>> UpdateAsync(ReadUpdateDTO code);
        //-----------------------------
        //--------- DELETE ------------
        //-----------------------------
        Task<ServiceResponse<Guid>> DeleteAsync(Guid id);
    }
}
