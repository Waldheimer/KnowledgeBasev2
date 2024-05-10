using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Commands.CodeCommands
{
    public class CreateNewCodeCommand : IRequest<ServiceResponse<Guid>>
    {
        public CreateDTO Dto { get; set; }

        public CreateNewCodeCommand(CreateDTO dto)
        {
            Dto = dto;
        }
    }
}
