using KnowledgeBasev2.Application.Commands.CodeCommands;
using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Application.Queries.CodeQueries;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBasev2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        private readonly IMediator mediator;

        public CodeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ServiceResponse<Guid>> CreateCode([FromBody] CreateDTO dto)
        {
            return await mediator.Send(new CreateNewCodeCommand(dto));
        }
        [HttpGet]
        public async Task<IEnumerable<ReadUpdateDTO>> GetCodes()
        {
            return await mediator.Send(new GetCodesListQuery());
        }
        [HttpGet("{id}")]
        public async Task<ReadUpdateDTO> GetCodeById(Guid id)
        {
            return await mediator.Send(new GetCodeByIdQuery(id));
        }

        [HttpPut]
        public async Task<ServiceResponse<Guid>> UpdateCode([FromBody] ReadUpdateDTO dto)
        {
            return await mediator.Send(new UpdateCodeCommand(dto));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<Guid>> DeleteCode(Guid id)
        {
            return await mediator.Send(new DeleteCodeCommand(id));
        }
    }
}
