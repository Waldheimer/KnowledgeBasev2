using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.Queries.DocumentationQueries;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.DocumentationHandler
{
    public class GetDocumentationsListQueryHandler : IRequestHandler<GetDocumentationsListQuery, IEnumerable<ReadUpdateDTO>>
    {
        private readonly IKbDocumentation _repo;

        public GetDocumentationsListQueryHandler(IKbDocumentation repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> Handle(GetDocumentationsListQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync();
        }
    }
}
