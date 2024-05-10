using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Commands.DocumentationsCommands
{
    public class UpdateDocumentationCommand : IRequest<ServiceResponse<Guid>>
    {
        public ReadUpdateDTO Dto { get; set; }

        public UpdateDocumentationCommand(ReadUpdateDTO dto)
        {
            Dto = dto;
        }
    }
}
