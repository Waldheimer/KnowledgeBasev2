using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Commands
{
    public class DeleteCmdCommand : IRequest<ServiceResponse<Guid>>
    {
        public Guid Id { get; set; }

        public DeleteCmdCommand(Guid id)
        {
            Id = id;
        }
    }
}
