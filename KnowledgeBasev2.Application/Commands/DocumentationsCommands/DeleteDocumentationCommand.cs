using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Commands.DocumentationsCommands
{
    public class DeleteDocumentationCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public DeleteDocumentationCommand(Guid id)
        {
            Id = id;
        }
    }
}
