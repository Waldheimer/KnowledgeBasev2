using KnowledgeBasev2.Application.Commands.DocumentationsCommands;
using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.DocumentationHandler
{
    public class DeleteDocumentationCommandHandler : IRequestHandler<DeleteDocumentationCommand, ServiceResponse<Guid>>
    {
        private readonly IKbDocumentation _repo;

        public DeleteDocumentationCommandHandler(IKbDocumentation repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<Guid>> Handle(DeleteDocumentationCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteAsync(request.Id);
        }
    }
}
