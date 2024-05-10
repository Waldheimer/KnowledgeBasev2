using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.Queries.CodeQueries;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Infrastructure.Handler.CodeHandler
{
    public class GetCodeByIdQueryHandler : IRequestHandler<GetCodeByIdQuery, ReadUpdateDTO>
    {
        private readonly IKbCode _repo;

        public GetCodeByIdQueryHandler(IKbCode repo)
        {
            _repo = repo;
        }

        public async Task<ReadUpdateDTO> Handle(GetCodeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}
