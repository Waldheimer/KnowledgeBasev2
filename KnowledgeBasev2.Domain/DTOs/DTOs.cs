using KnowledgeBasev2.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBasev2.Domain.DTOs
{
    public class ValueDTO
    {
        public string System { get; set; } = string.Empty;
        public string Tech { get; set; } = string.Empty;
        public string Lang { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
    }
    public class NoIdDTO : ValueDTO
    {
        [Required]
        public string Text { get; set; } = string.Empty;
    }
    public class IdDTO : NoIdDTO
    {
        [Required]
        public Guid Id { get; set; }
    }
    public class CreateDTO : NoIdDTO {}
    public class ReadUpdateDTO : IdDTO 
    {
        public ReadUpdateDTO() { }
        public ReadUpdateDTO(KBCommand command, KBDescriptor descriptor, KBDescription description)
        {
            this.Id = command.Descriptor;
            this.Text = command.Command;
            this.System = descriptor.System;
            this.Tech = descriptor.Tech;
            this.Lang = descriptor.Lang;
            this.Description = description.DescriptionText;
            this.Version = description.Version;
        }
        public ReadUpdateDTO(KBCode code, KBDescriptor descriptor, KBDescription description)
        {
            this.Id = code.Descriptor;
            this.Text = code.Code;
            this.System = descriptor.System;
            this.Tech = descriptor.Tech;
            this.Lang = descriptor.Lang;
            this.Description = description.DescriptionText;
            this.Version = description.Version;
        }
        public ReadUpdateDTO(KBDocumentation documentation, KBDescriptor descriptor, KBDescription description)
        {
            this.Id = documentation.Descriptor;
            this.Text = documentation.Documentation;
            this.System = descriptor.System;
            this.Tech = descriptor.Tech;
            this.Lang = descriptor.Lang;
            this.Description = description.DescriptionText;
            this.Version = description.Version;
        }

        public static ReadUpdateDTO Default => new ReadUpdateDTO{ 
            Id =  Guid.Empty,
            Text = string.Empty,
            System = string.Empty,
            Tech = string.Empty,
            Lang = string.Empty,
            Description = string.Empty,
            Version = string.Empty
        };
    }
}
