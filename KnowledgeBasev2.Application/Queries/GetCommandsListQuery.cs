using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Queries
{
    public class GetCommandsListQuery : IRequest<IEnumerable<ReadUpdateDTO>> { }
}
