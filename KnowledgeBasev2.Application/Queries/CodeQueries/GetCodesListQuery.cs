using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Queries.CodeQueries
{
    public class GetCodesListQuery : IRequest<IEnumerable<ReadUpdateDTO>>
    {
    }
}
