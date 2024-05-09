using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.Domain.Entities;

namespace KnowledgeBasev2.Tests.Entities
{
    public class FromDTO_Tests
    {
        private readonly KBCommand _command;
        private readonly KBCode _code;
        private readonly KBDocumentation _documentation;
        private readonly KBDescriptor _descriptor;
        private readonly KBDescription _description;

        private readonly ReadUpdateDTO _CommandReadUpdateDTO, _CodeReadUpdateDTO, _DocumentationReadUpdateDTO;
        private readonly CreateDTO _createDTO;


        /// <summary>
        /// Hardcoded Values for Testing
        /// </summary>
        public FromDTO_Tests()
        {
            Guid guid = Guid.NewGuid();
            _command = new KBCommand { Command = "Some Command", Descriptor = guid };
            _code = new KBCode { Code = "Some Code", Descriptor = guid };
            _documentation = new KBDocumentation { Documentation = "Some Documentation", Descriptor = guid };
            _descriptor = new KBDescriptor { Id = guid, System = "Windows", Tech = "DotNet Core", Lang = "C#" };
            _description = new KBDescription { Id = guid, DescriptionText = "Some extended Description", Version = "1.0.0" };
            _CommandReadUpdateDTO = new ReadUpdateDTO 
            { 
                Id = guid, 
                Text = "Some Command", 
                System = "Windows", 
                Tech = "DotNet Core", 
                Lang = "C#", 
                Description = "Some extended Description", 
                Version = "1.0.0" 
            };
            _CodeReadUpdateDTO = new ReadUpdateDTO
            {
                Id = guid,
                Text = "Some Code",
                System = "Windows",
                Tech = "DotNet Core",
                Lang = "C#",
                Description = "Some extended Description",
                Version = "1.0.0"
            };
            _DocumentationReadUpdateDTO = new ReadUpdateDTO
            {
                Id = guid,
                Text = "Some Documentation",
                System = "Windows",
                Tech = "DotNet Core",
                Lang = "C#",
                Description = "Some extended Description",
                Version = "1.0.0"
            };

        }

        [Fact]
        public void DtoShouldBeCreatedCorrectly()
        {
            ReadUpdateDTO cmddto = new ReadUpdateDTO(_command,_descriptor,_description);
            ReadUpdateDTO cddto = new ReadUpdateDTO(_code, _descriptor, _description);
            ReadUpdateDTO docdto = new ReadUpdateDTO(_documentation, _descriptor, _description);


            Assert.Equivalent(cmddto, _CommandReadUpdateDTO);
            Assert.Equivalent(cddto, _CodeReadUpdateDTO);
            Assert.Equivalent(docdto, _DocumentationReadUpdateDTO);
        }

        [Fact]
        public void EntityShouldBeCreatedCorrectlyFromDTOs()
        {
            var cmd = KBCommand.fromDTO(_CommandReadUpdateDTO);
            var code = KBCode.fromDTO(_CodeReadUpdateDTO);
            var doc = KBDocumentation.fromDTO(_DocumentationReadUpdateDTO);

            Assert.Equivalent(_command, cmd);
            Assert.Equivalent(_code, code);
            Assert.Equivalent(_documentation, doc);
        }
    }
}
