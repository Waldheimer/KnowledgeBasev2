using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CommandHandler
{
    public class CreateNewCmdCommandHandler : IRequestHandler<CreateNewCmdCommand, ServiceResponse<Guid>>
    {
        private readonly IKbCommand _repo;

        public CreateNewCmdCommandHandler(IKbCommand repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateNewCmdCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CreateAsync(request.Input);
        }
    }
}
