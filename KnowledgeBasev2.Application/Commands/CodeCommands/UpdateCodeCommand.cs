using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Commands.CodeCommands
{
    public class UpdateCodeCommand : IRequest<ServiceResponse<Guid>>
    {
        public ReadUpdateDTO Dto { get; set; }

        public UpdateCodeCommand(ReadUpdateDTO dto)
        {
            Dto = dto;
        }
    }
}
