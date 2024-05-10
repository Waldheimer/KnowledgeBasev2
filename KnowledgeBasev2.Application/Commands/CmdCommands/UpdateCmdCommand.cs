using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;

namespace KnowledgeBasev2.Application.Commands.CmdCommands
{
    public class UpdateCmdCommand : IRequest<ServiceResponse<Guid>>
    {
        public ReadUpdateDTO Dto { get; set; }

        public UpdateCmdCommand(ReadUpdateDTO dto)
        {
            Dto = dto;
        }
    }
}
