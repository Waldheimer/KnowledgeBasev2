using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CommandHandler
{
    public class DeleteCmdCommandHandler : IRequestHandler<DeleteCmdCommand, ServiceResponse<Guid>>
    {
        private readonly IKbCommand _repo;

        public DeleteCmdCommandHandler(IKbCommand repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteCmdCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteAsync(request.Id);
        }
    }
}
