using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.Queries.CommandQueries;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CommandHandler
{
    public class GetCommandByIdQueryHandler : IRequestHandler<GetCommandByIdQuery, ReadUpdateDTO>
    {
        private readonly IKbCommand _repo;

        public GetCommandByIdQueryHandler(IKbCommand repo)
        {
            _repo = repo;
        }

        public Task<ReadUpdateDTO> Handle(GetCommandByIdQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetByIdAsync(request.Id);
        }
    }
}
