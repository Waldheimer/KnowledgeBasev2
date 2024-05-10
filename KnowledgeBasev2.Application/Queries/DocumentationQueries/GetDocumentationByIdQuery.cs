using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Queries.DocumentationQueries
{
    public class GetDocumentationByIdQuery : IRequest<ReadUpdateDTO>
    {
        public Guid Id { get; set; }
        public GetDocumentationByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
