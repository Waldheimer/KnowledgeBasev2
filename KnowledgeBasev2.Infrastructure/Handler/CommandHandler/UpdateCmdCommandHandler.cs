using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Infrastructure.ContractImplementations;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CommandHandler
{
    public class UpdateCmdCommandHandler : IRequestHandler<UpdateCmdCommand, ServiceResponse<Guid>>
    {
        private readonly KBCommandRepo _repo;

        public UpdateCmdCommandHandler(KBCommandRepo repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateCmdCommand request, CancellationToken cancellationToken)
        {
            return await _repo.UpdateAsync(request.Dto);
        }
    }
}
