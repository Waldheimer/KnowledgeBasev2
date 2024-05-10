using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.Queries.DocumentationQueries;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.DocumentationHandler
{
    public class GetDocumentationByIdQueryHandler : IRequestHandler<GetDocumentationByIdQuery, ReadUpdateDTO>
    {
        private readonly IKbDocumentation _repo;

        public GetDocumentationByIdQueryHandler(IKbDocumentation repo)
        {
            _repo = repo;
        }

        public async Task<ReadUpdateDTO> Handle(GetDocumentationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}
