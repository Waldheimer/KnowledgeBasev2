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
    public class CreateNewCmdCommand : IRequest<ServiceResponse<Guid>> 
    { 
        public CreateDTO Input {  get; set; }

        public CreateNewCmdCommand(CreateDTO input)
        {
            Input = input;
        }
    }
}
