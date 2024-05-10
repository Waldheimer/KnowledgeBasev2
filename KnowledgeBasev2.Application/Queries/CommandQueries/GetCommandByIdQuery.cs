using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Queries.CommandQueries
{
    public class GetCommandByIdQuery : IRequest<ReadUpdateDTO>
    {
        public Guid Id { get; set; }

        public GetCommandByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
