using KnowledgeBasev2.Application.Commands.CodeCommands;
using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CodeHandler
{
    public class DeleteCodeCommandHandler : IRequestHandler<DeleteCodeCommand, ServiceResponse<Guid>>
    {
        private readonly IKbCode _repo;

        public DeleteCodeCommandHandler(IKbCode repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteCodeCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteAsync(request.Id);
        }
    }
}
