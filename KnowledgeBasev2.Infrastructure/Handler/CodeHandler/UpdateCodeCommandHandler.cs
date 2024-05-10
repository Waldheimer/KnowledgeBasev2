using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.Commands.CodeCommands;
using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CodeHandler
{
    public class UpdateCodeCommandHandler : IRequestHandler<UpdateCodeCommand, ServiceResponse<Guid>>
    {
        private readonly IKbCode _repo;

        public UpdateCodeCommandHandler(IKbCode repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateCodeCommand request, CancellationToken cancellationToken)
        {
            return await _repo.UpdateAsync(request.Dto);
        }
    }
}
