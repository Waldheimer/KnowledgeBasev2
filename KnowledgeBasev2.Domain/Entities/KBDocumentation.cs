using KnowledgeBasev2.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBasev2.Domain.Entities
{
    public class KBDocumentation
    {
        [Key]
        public Guid Descriptor { get; set; }
        public string Documentation { get; set; } = string.Empty;

        public static KBDocumentation fromDTO(IdDTO dto)
        {
            return new KBDocumentation { Descriptor = dto.Id, Documentation = dto.Text };
        }
        public static KBDocumentation fromDTO(NoIdDTO dto, Guid id)
        {
            return new KBDocumentation { Descriptor = id, Documentation = dto.Text };
        }
    }
}
