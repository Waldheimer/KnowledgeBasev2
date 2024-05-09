using KnowledgeBasev2.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBasev2.Domain.Entities
{
    public class KBCode
    {
        [Key]
        public Guid Descriptor { get; set; }
        public string Code { get; set; } = string.Empty;

        public static KBCode fromDTO(IdDTO dto)
        {
            return new KBCode { Descriptor = dto.Id, Code = dto.Text };
        }
        public static KBCode fromDTO(NoIdDTO dto, Guid id)
        {
            return new KBCode { Descriptor = id, Code = dto.Text };
        }
    }
}
