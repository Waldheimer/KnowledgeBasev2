using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CommandHandler
{
    public class UpdateCmdCommandHandler : IRequestHandler<UpdateCmdCommand, ServiceResponse<Guid>>
    {
        private readonly IKbCommand _repo;

        public UpdateCmdCommandHandler(IKbCommand repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateCmdCommand request, CancellationToken cancellationToken)
        {
            return await _repo.UpdateAsync(request.Dto);
        }
    }
}
