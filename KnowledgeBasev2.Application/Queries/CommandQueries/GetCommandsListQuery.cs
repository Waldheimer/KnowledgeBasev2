using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Queries.CommandQueries
{
    public class GetCommandsListQuery : IRequest<IEnumerable<ReadUpdateDTO>> { }
}
