using KnowledgeBasev2.Application.Commands.DocumentationsCommands;
using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.DocumentationHandler
{
    public class UpdateDocumentationCommandHandler : IRequestHandler<UpdateDocumentationCommand, ServiceResponse<Guid>>
    {
        private readonly IKbDocumentation _repo;

        public UpdateDocumentationCommandHandler(IKbDocumentation repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<Guid>> Handle(UpdateDocumentationCommand request, CancellationToken cancellationToken)
        {
            return await _repo.UpdateAsync(request.Dto);
        }
    }
}
