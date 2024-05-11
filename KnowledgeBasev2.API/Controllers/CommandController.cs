using FluentValidation;
using KnowledgeBasev2.Application.Commands.CmdCommands;
using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Application.Queries.CommandQueries;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBasev2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        //---------------------------------------
        //--------- COSNTRCUTOR -----------------
        //---------------------------------------
        private readonly IMediator mediator;
        private readonly IValidator<CreateNewCmdCommand> ccmdValidator;
        private readonly IValidator<GetCommandByIdQuery> gcmdValidator;
        private readonly IValidator<UpdateCmdCommand> ucmdValidator;
        private readonly IValidator<DeleteCmdCommand> dcmdValidator;

        public CommandController(IMediator mediator, 
            IValidator<CreateNewCmdCommand> cval,
            IValidator<GetCommandByIdQuery> gval,
            IValidator<UpdateCmdCommand> uval,
            IValidator<DeleteCmdCommand> dval)
        {
            this.mediator = mediator;
            this.ccmdValidator = cval;
            this.gcmdValidator = gval;
            this.ucmdValidator = uval;
            this.dcmdValidator = dval;
        }

        //---------------------------------------
        //--------- POST / CREATE ---------------
        //---------------------------------------
        [HttpPost]
        public async Task<ServiceResponse<Guid>> CreateCommand([FromBody] CreateDTO dto)
        {
            var command = new CreateNewCmdCommand(dto);
            var validationResult = await ccmdValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return new ServiceResponse<Guid>(true,"Validation Error, Either Text/Command missing or duplicate Text/Command",Guid.Empty);
            }
            return await mediator.Send(command);
        }

        //---------------------------------------
        //--------- GET / READ ------------------
        //---------------------------------------
        [HttpGet]
        public async Task<IEnumerable<ReadUpdateDTO>> GetCommands()
        {
            return await mediator.Send(new GetCommandsListQuery());
        }
        [HttpGet("{id}")]
        public async Task<ReadUpdateDTO> GetCommandById(Guid id)
        {
            var command = new GetCommandByIdQuery(id);
            var validationResult = await gcmdValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return ReadUpdateDTO.Default;
            }
            return await mediator.Send(command);
        }

        //---------------------------------------
        //--------- PUT/ UPDATE -----------------
        //---------------------------------------
        [HttpPut]
        public async Task<ServiceResponse<Guid>> UpdateCommand([FromBody] ReadUpdateDTO dto)
        {
            var command = new UpdateCmdCommand(dto);
            var validationResult = await ucmdValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return new ServiceResponse<Guid>(true, "No Command with given Id", dto.Id);
            }
            return await mediator.Send(command);
        }

        //---------------------------------------
        //--------- DELETE / DELETE -------------
        //---------------------------------------
        [HttpDelete("{id}")]
        public async Task<ServiceResponse<Guid>> DeleteCommand(Guid id)
        {
            var command = new DeleteCmdCommand(id);
            var validationResult = await dcmdValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return new ServiceResponse<Guid>(true, "No Command with given Id", id);
            }
            return await mediator.Send(new DeleteCmdCommand(id));
        }

    }
}
