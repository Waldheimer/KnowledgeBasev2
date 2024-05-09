using KnowledgeBasev2.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBasev2.Domain.Entities
{
    public class KBDescription
    {
        [Key]
        public Guid Id { get; set; }
        public string DescriptionText { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;

        public static KBDescription fromDTO(IdDTO dto)
        {
            return new KBDescription { Id = dto.Id, DescriptionText = dto.Description, Version = dto.Version };
        }
        public static KBDescription fromDTO(NoIdDTO dto, Guid id)
        {
            return new KBDescription { Id = id, DescriptionText = dto.Description, Version = dto.Version };
        }
    }
}
