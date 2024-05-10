using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Infrastructure.ContractImplementations;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CommandHandler
{
    public class DeleteCmdCommandHandler : IRequestHandler<DeleteCmdCommand, ServiceResponse<Guid>>
    {
        private readonly KBCommandRepo _repo;

        public DeleteCmdCommandHandler(KBCommandRepo repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteCmdCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteAsync(request.Id);
        }
    }
}
