using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Queries.CodeQueries
{
    public class GetCodeByIdQuery : IRequest<ReadUpdateDTO>
    {
        public Guid Id { get; set; }

        public GetCodeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
