using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.Queries.CodeQueries;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CodeHandler
{
    public class GetCodesListQueryHandler : IRequestHandler<GetCodesListQuery, IEnumerable<ReadUpdateDTO>>
    {
        private readonly IKbCode _repo;

        public GetCodesListQueryHandler(IKbCode repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ReadUpdateDTO>> Handle(GetCodesListQuery request, CancellationToken cancellationToken)
        => await _repo.GetAsync();
    }
}
