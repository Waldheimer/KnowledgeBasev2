using KnowledgeBasev2.Application.Commands.DocumentationsCommands;
using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.DocumentationHandler
{
    public class CreateNewDocumentationCommandHandler : IRequestHandler<CreateNewDocumentationCommand, ServiceResponse<Guid>>
    {
        private readonly IKbDocumentation _repo;

        public CreateNewDocumentationCommandHandler(IKbDocumentation repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreateNewDocumentationCommand request, CancellationToken cancellationToken)
        {
            return await _repo.CreateAsync(request.Dto);
        }
    }
}
