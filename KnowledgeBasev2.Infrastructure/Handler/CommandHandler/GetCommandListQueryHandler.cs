using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.Queries.CommandQueries;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CommandHandler
{
    public class GetCommandListQueryHandler : IRequestHandler<GetCommandsListQuery, IEnumerable<ReadUpdateDTO>>
    {
        private readonly IKbCommand _repo;
        public GetCommandListQueryHandler(IKbCommand repo)
        {
            this._repo = repo;
        }

        public Task<IEnumerable<ReadUpdateDTO>> Handle(GetCommandsListQuery request, CancellationToken cancellationToken)
        => _repo.GetAsync();
    }
}
