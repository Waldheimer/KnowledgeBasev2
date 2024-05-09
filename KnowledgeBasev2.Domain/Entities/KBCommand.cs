using KnowledgeBasev2.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBasev2.Domain.Entities
{
    public class KBCommand
    {
        [Key]
        public Guid Descriptor { get; set; }
        public string Command {  get; set; } = string.Empty;

        public static KBCommand fromDTO(NoIdDTO dto, Guid id)
        {
            return new KBCommand { Descriptor = id, Command = dto.Text };
        }
        public static KBCommand fromDTO(IdDTO dto)
        {
            return new KBCommand { Descriptor = dto.Id, Command = dto.Text };
        }
    }
}
