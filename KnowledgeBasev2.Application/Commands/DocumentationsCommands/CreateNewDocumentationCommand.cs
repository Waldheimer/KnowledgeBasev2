using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Commands.DocumentationsCommands
{
    public class CreateNewDocumentationCommand : IRequest<ServiceResponse<Guid>>
    {
        public CreateDTO Dto { get; set; }

        public CreateNewDocumentationCommand(CreateDTO dto)
        {
            Dto = dto;
        }
    }
}
