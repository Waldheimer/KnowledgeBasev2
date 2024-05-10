using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Commands.CodeCommands
{
    public class DeleteCodeCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public DeleteCodeCommand(Guid id)
        {
            Id = id;
        }
    }
}
