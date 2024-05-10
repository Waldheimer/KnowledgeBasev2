using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Queries.DocumentationQueries
{
    public class GetDocumentationsListQuery : IRequest<IEnumerable<ReadUpdateDTO>>
    {
    }
}
