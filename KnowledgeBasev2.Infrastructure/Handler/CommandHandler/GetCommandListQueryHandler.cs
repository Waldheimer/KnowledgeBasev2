using KnowledgeBasev2.Application.Queries.CommandQueries;
using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.Infrastructure.ContractImplementations;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CommandHandler
{
    public class GetCommandListQueryHandler : IRequestHandler<GetCommandsListQuery, IEnumerable<ReadUpdateDTO>>
    {
        private readonly KBCommandRepo _repo;
        public GetCommandListQueryHandler(KBCommandRepo repo)
        {
            this._repo = repo;
        }

        public Task<IEnumerable<ReadUpdateDTO>> Handle(GetCommandsListQuery request, CancellationToken cancellationToken)
        => _repo.GetAsync();
    }
}
