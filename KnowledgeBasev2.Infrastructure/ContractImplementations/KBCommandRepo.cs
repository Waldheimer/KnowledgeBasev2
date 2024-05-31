using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.Domain.Entities;
using KnowledgeBasev2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBasev2.Infrastructure.ContractImplementations
{
    public class KBCommandRepo : IKbCommand
    {
        private readonly RemoteDbContext context;

        public KBCommandRepo(RemoteDbContext context)
        {
            this.context = context;
        }

        //-----------------------------
        //--------- CREATE ------------
        //-----------------------------

        /// <summary>
        /// Create a new command from a CreateDTO including Descriptor and Description and save them to the Database
        /// </summary>
        public async Task<ServiceResponse<Guid>> CreateAsync(CreateDTO dto)
        {
            Guid guid = Guid.NewGuid();
            var cmd = context.Commands.Add(KBCommand.fromDTO(dto, guid));
            var dtr = context.Descriptors.Add(KBDescriptor.fromDTO(dto, guid));
            var dtn = context.Descriptions.Add(KBDescription.fromDTO(dto, guid));
            if(cmd is null || dtr is null || dtn is null)
            {
                return new ServiceResponse<Guid>(true, "Something went wrong while saving the data", Guid.Empty);
            }
            else
            {
                await SaveChangesAsync();
                return new ServiceResponse<Guid>(false, "New command successfully created", guid);
            }
        }


        //-----------------------------
        //--------- READ --------------
        //-----------------------------

        /// <summary>
        /// Get all available commands from the Database and returns them as ReadUpdateDTO
        /// including the data from the descriptor and description
        /// </summary>
        public async Task<IEnumerable<ReadUpdateDTO>> GetAsync()
        {
            var result = from cmd in context.Commands.AsNoTracking()
                         from descriptor in context.Descriptors.AsNoTracking()
                         from description in context.Descriptions.AsNoTracking()
                         where descriptor.Id.Equals(cmd.Descriptor) && description.Id.Equals(cmd.Descriptor)
                         select new ReadUpdateDTO(cmd, descriptor, description);
            return result;
        }

        /// <summary>
        /// Gets the command/Descriptor/Description with the given Id from the Database and combines the data into a single ReadUpdateDTO
        /// </summary>
        public async Task<ReadUpdateDTO> GetByIdAsync(Guid id)
        {
            var cmd = await context.Commands.FirstAsync(c => c.Descriptor.Equals(id));
            var dct = await context.Descriptors.FirstAsync(d => d.Id.Equals(id));
            var dtn = await context.Descriptions.FirstAsync(d => d.Id.Equals(id));
            if(cmd is null || dct is null || dtn is null)
            {
                return ReadUpdateDTO.Default;
            }
            else
            {
                return new ReadUpdateDTO(cmd, dct, dtn);
            }
        }

        /// <summary>
        /// Get all available commands from the Dabatase with the given "Lang"uage or a partly match
        /// </summary>
        public async Task<IEnumerable<ReadUpdateDTO>> GetByLangAsync(string lang)
        {
            var descriptors = context.Descriptors.AsNoTracking().Where(c => c.Lang.Contains(lang) || lang.Contains(c.Lang));
            var commands = from cmd in context.Commands.AsNoTracking()
                           from dtn in context.Descriptions.AsNoTracking()
                           from id in descriptors
                           where cmd.Descriptor.Equals(id.Id) && dtn.Id.Equals(id.Id)
                           select new ReadUpdateDTO(cmd, id, dtn);
            return await commands.ToListAsync();
        }

        /// <summary>
        /// Get all available commands from the Dabatase with the given "System" or a partly match
        /// </summary>
        public async Task<IEnumerable<ReadUpdateDTO>> GetBySystemAsync(string system)
        {
            var descriptors = context.Descriptors.AsNoTracking().Where(c => c.System.Contains(system) || system.Contains(c.System));
            var commands = from cmd in context.Commands.AsNoTracking()
                           from dtn in context.Descriptions.AsNoTracking()
                           from id in descriptors
                           where cmd.Descriptor.Equals(id.Id) && dtn.Id.Equals(id.Id)
                           select new ReadUpdateDTO(cmd, id, dtn);
            return await commands.ToListAsync();
        }

        /// <summary>
        /// Get all available commands from the Dabatase with the given Tech or a partly match
        /// </summary>
        public async Task<IEnumerable<ReadUpdateDTO>> GetByTechAsync(string tech)
        {
            var descriptors = context.Descriptors.AsNoTracking().Where(c => c.Tech.Contains(tech) || tech.Contains(c.Tech));
            var commands = from cmd in context.Commands.AsNoTracking()
                           from dtn in context.Descriptions.AsNoTracking()
                           from id in descriptors
                           where cmd.Descriptor.Equals(id.Id) && dtn.Id.Equals(id.Id)
                           select new ReadUpdateDTO(cmd, id, dtn);
            return await commands.ToListAsync();
        }


        //-----------------------------
        //--------- UPDATE ------------
        //-----------------------------
        /// <summary>
        /// Update the command/Descriptor/Description matching the ReadUpdateDTO
        /// </summary>
        public async Task<ServiceResponse<Guid>> UpdateAsync(ReadUpdateDTO dto)
        {
            var cmd = KBCommand.fromDTO(dto);
            var dtr = KBDescriptor.fromDTO(dto);
            var dtn = KBDescription.fromDTO(dto);
            var cmd_res = context.Commands.Update(cmd);
            var dtr_res = context.Descriptors.Update(dtr);
            var dtn_res = context.Descriptions.Update(dtn);

            if(cmd_res is null || dtr_res is null || dtn_res is null)
            {
                return new ServiceResponse<Guid>(true, "Error Updating command", Guid.Empty);
            }
            else
            {
                await SaveChangesAsync();
                return new ServiceResponse<Guid>(false, "command Updated", dto.Id);
            }
        }


        //-----------------------------
        //--------- DELETE ------------
        //-----------------------------
        /// <summary>
        /// Deletes the command/Descriptor/Description with the given id
        /// </summary>
        public async Task<ServiceResponse<Guid>> DeleteAsync(Guid id)
        {
            var cmd = await context.Commands.FindAsync(id);
            var dtr = await context.Descriptors.FindAsync(id);
            var dtn = await context.Descriptions.FindAsync(id);

            if(cmd is null || dtr is null || dtn is null)
            {
                return new ServiceResponse<Guid>(true, $"Could not delete {id}", Guid.Empty);
            }
            else
            {
                context.Commands.Remove(cmd);
                context.Descriptors.Remove(dtr);
                context.Descriptions.Remove(dtn);
                await SaveChangesAsync();
                return new ServiceResponse<Guid>(false, "command successfully deleted", id);
            }
        }

        //-----------------------------
        //--------- VALIDATION --------
        //-----------------------------
        public async Task<bool> IsUniqueCommand(CreateDTO command)
        {
            return !await context.Commands.AnyAsync(c => c.Command.Equals(command.Text));
        }

        public Task<bool> HasRequiredData(CreateDTO command)
        {
            return Task.FromResult(!string.IsNullOrEmpty(command.Text));
        }

        public async Task<bool> HasValidExistingId(ReadUpdateDTO command)
        {
            var there = !string.IsNullOrEmpty(command.Id.ToString());
            var exists = await context.Commands.AnyAsync(c => c.Descriptor.Equals(command.Id));

            return await Task.FromResult(there && exists);
        }
        public async Task<bool> IsExistingId(Guid id)
        {
            return await context.Commands.AnyAsync(c => c.Descriptor.Equals(id));
        }

        //-----------------------------
        //--------- SAVE CHANGES ------
        //-----------------------------
        private async Task SaveChangesAsync() => await context.SaveChangesAsync();

    }
}
