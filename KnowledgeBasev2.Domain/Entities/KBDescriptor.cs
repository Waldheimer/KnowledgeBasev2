using KnowledgeBasev2.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBasev2.Domain.Entities
{
    public class KBDescriptor
    {
        [Key]
        public Guid Id { get; set; }
        public string System { get; set; } = string.Empty;
        public string Tech { get; set; } = string.Empty;
        public string Lang { get; set; } = string.Empty;
        
        public static KBDescriptor fromDTO(IdDTO dto)
        {
            return new KBDescriptor { Id = dto.Id, System = dto.System, Tech = dto.Tech, Lang = dto.Lang };
        }
        public static KBDescriptor fromDTO(NoIdDTO dto, Guid id)
        {
            return new KBDescriptor { Id = id, System = dto.System, Tech = dto.Tech, Lang = dto.Lang };
        }
    }

}
