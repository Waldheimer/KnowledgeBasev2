using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Infrastructure.ContractImplementations;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CommandHandler
{
    public class CreateNewCmdCommandHandler : IRequestHandler<CreateNewCmdCommand, ServiceResponse<Guid>>
    {
        private readonly KBCommandRepo _repo;

        public CreateNewCmdCommandHandler(KBCommandRepo repo)
        {
            _repo = repo;
        }

        public Task<ServiceResponse<Guid>> Handle(CreateNewCmdCommand request, CancellationToken cancellationToken)
        {
            return _repo.CreateAsync(request.Input);
        }
    }
}
