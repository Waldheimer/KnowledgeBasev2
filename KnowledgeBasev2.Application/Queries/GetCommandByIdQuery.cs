using KnowledgeBasev2.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBasev2.Application.Queries
{
    public class GetCommandByIdQuery : IRequest<ReadUpdateDTO>
    {
        public Guid Id { get; set; }

        public GetCommandByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
