using KnowledgeBasev2.Application.Commands;
using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Application.Queries;
using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.Infrastructure.Handler.CommandHandler;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBasev2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly IMediator mediator;

        public CommandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ServiceResponse<Guid>> CreateCommand([FromBody] CreateDTO dto)
        {
            return await mediator.Send(new CreateNewCmdCommand(dto));
        }
        [HttpGet]
        public async Task<IEnumerable<ReadUpdateDTO>> GetCommands()
        {
            return await mediator.Send(new GetCommandsListQuery());
        }
        [HttpGet("{id}")]
        public async Task<ReadUpdateDTO> GetCommandById(Guid id)
        {
            return await mediator.Send(new GetCommandByIdQuery(id));
        }

        [HttpPut]
        public async Task<ServiceResponse<Guid>> UpdateCommand([FromBody] ReadUpdateDTO dto)
        {
            return await mediator.Send(new UpdateCmdCommand(dto));
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<Guid>> DeleteCommand(Guid id)
        {
           return await mediator.Send(new DeleteCmdCommand(id));
        }

    }
}
