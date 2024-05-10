using KnowledgeBasev2.Application.Queries.CommandQueries;
using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.Infrastructure.ContractImplementations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBasev2.Infrastructure.Handler.CommandHandler
{
    public class GetCommandByIdQueryHandler : IRequestHandler<GetCommandByIdQuery, ReadUpdateDTO>
    {
        private readonly KBCommandRepo _repo;

        public GetCommandByIdQueryHandler(KBCommandRepo repo)
        {
            _repo = repo;
        }

        public Task<ReadUpdateDTO> Handle(GetCommandByIdQuery request, CancellationToken cancellationToken)
        {
            return _repo.GetByIdAsync(request.Id);
        }
    }
}
