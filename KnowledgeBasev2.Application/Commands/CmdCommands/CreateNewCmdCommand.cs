using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Commands.CmdCommands
{
    public class CreateNewCmdCommand : IRequest<ServiceResponse<Guid>>
    {
        public CreateDTO Input { get; set; }

        public CreateNewCmdCommand(CreateDTO input)
        {
            Input = input;
        }
    }
}
