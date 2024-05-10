using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBasev2.Application.Commands
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
