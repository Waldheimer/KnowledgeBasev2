using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.Commands.CodeCommands;
using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CodeHandler
{
    public class CreateNewCodeCommandHandler : IRequestHandler<CreateNewCodeCommand, ServiceResponse<Guid>>
    {
        private readonly IKbCode _repo;

        public CreateNewCodeCommandHandler(IKbCode repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateNewCodeCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CreateAsync(request.Dto);
        }
    }
}
