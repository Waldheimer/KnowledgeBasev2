using KnowledgeBasev2.Application.Commands.DocumentationsCommands;
using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Application.Queries.DocumentationQueries;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBasev2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentationController : ControllerBase
    {
        private readonly IMediator mediator;

        public DocumentationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ServiceResponse<Guid>> CreateDocumentation([FromBody] CreateDTO dto)
        {
            return await mediator.Send(new CreateNewDocumentationCommand(dto));
        }
        [HttpGet]
        public async Task<IEnumerable<ReadUpdateDTO>> GetDocumentations()
        {
            return await mediator.Send(new GetDocumentationsListQuery());
        }
        [HttpGet("{id}")]
        public async Task<ReadUpdateDTO> GetDocumentationById(Guid id)
        {
            return await mediator.Send(new GetDocumentationByIdQuery(id));
        }

        [HttpPut]
        public async Task<ServiceResponse<Guid>> UpdateDocumentation([FromBody] ReadUpdateDTO dto)
        {
            return await mediator.Send(new UpdateDocumentationCommand(dto));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<Guid>> DeleteDocumentation(Guid id)
        {
            return await mediator.Send(new DeleteDocumentationCommand(id));
        }
    }
}
