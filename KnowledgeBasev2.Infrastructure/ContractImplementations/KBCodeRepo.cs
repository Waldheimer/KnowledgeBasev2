using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.Domain.Entities;
using KnowledgeBasev2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBasev2.Infrastructure.ContractImplementations
{
    public class KBCodeRepo : IKbCode
    {
        private readonly RemoteDbContext context;

        public KBCodeRepo(RemoteDbContext context)
        {
            this.context = context;
        }

        //-----------------------------
        //--------- CREATE ------------
        //-----------------------------
        /// <summary>
        /// Create a new Code from a CreateDTO including Descriptor and Description and save them to the Database
        /// </summary>
        /// <param name="code">The CreateDTO contains all required Information to create a new Code except the Guid</param>
        /// <returns>a ServiceResponse with an empty Guid if failed or the new Guid if successful</returns>
        public async Task<ServiceResponse<Guid>> CreateAsync(CreateDTO code)
        {
            Guid guid = Guid.NewGuid();
            var cmd = context.Codes.Add(KBCode.fromDTO(code, guid));
            var dtr = context.Descriptors.Add(KBDescriptor.fromDTO(code, guid));
            var dtn = context.Descriptions.Add(KBDescription.fromDTO(code, guid));
            if (cmd is null || dtr is null || dtn is null)
            {
                return new ServiceResponse<Guid>(true, "Something went wrong while saving the data", Guid.Empty);
            }
            else
            {
                await SaveChangesAsync();
                return new ServiceResponse<Guid>(false, "New code successfully created", guid);
            }
        }

        //-----------------------------
        //--------- READ --------------
        //-----------------------------
        /// <summary>
        /// Get all available Codes from the Database and returns them as ReadUpdateDTO
        /// including the data from the descriptor and description
        /// </summary>
        /// <returns>A List of Codes as ReadUpdateDTOs</returns>
        public async Task<IEnumerable<ReadUpdateDTO>> GetAsync()
        {
            var result = from code in context.Codes.AsNoTracking()
                         from descriptor in context.Descriptors.AsNoTracking()
                         from description in context.Descriptions.AsNoTracking()
                         where descriptor.Id.Equals(code.Descriptor) && description.Id.Equals(code.Descriptor)
                         select new ReadUpdateDTO(code, descriptor, description);
            return await result.ToListAsync();
        }

        /// <summary>
        /// Gets the code/Descriptor/Description with the given Id from the Database and combines the data into a single ReadUpdateDTO
        /// </summary>
        /// <param name="id">The Guid of the Descriptor connection code/Descriptor/Description</param>
        /// <returns>A single ReadUpdateDTO with the given id</returns>
        public async Task<ReadUpdateDTO> GetByIdAsync(Guid id)
        {
            var code = await context.Codes.FirstAsync(c => c.Descriptor.Equals(id));
            var dct = await context.Descriptors.FirstAsync(d => d.Id.Equals(id));
            var dtn = await context.Descriptions.FirstAsync(d => d.Id.Equals(id));
            if (code is null || dct is null || dtn is null)
            {
                return ReadUpdateDTO.Default;
            }
            else
            {
                return new ReadUpdateDTO(code, dct, dtn);
            }
        }

        /// <summary>
        /// Get all available codes from the Dabatase with the given "Lang"uage or a partly match
        /// </summary>
        /// <param name="lang">The "Lang"uage Property of the Descriptor</param>
        /// <returns>A List of all codes in the given lang</returns>
        public async Task<IEnumerable<ReadUpdateDTO>> GetByLangAsync(string lang)
        {
            var descriptors = context.Descriptors.AsNoTracking().Where(c => c.Lang.Contains(lang) || lang.Contains(c.Lang));
            var codes = from code in context.Codes.AsNoTracking()
                           from dtn in context.Descriptions.AsNoTracking()
                           from id in descriptors
                           where code.Descriptor.Equals(id.Id) && dtn.Id.Equals(id.Id)
                           select new ReadUpdateDTO(code, id, dtn);
            return await codes.ToListAsync();
        }

        /// <summary>
        /// Get all available codes from the Dabatase with the given "System" or a partly match
        /// </summary>
        /// <param name="lang">The System Property of the Descriptor</param>
        /// <returns>A List of all codes in the given system</returns>
        public async Task<IEnumerable<ReadUpdateDTO>> GetBySystemAsync(string system)
        {
            var descriptors = context.Descriptors.AsNoTracking().Where(c => c.System.Contains(system) || system.Contains(c.System));
            var codes = from code in context.Codes.AsNoTracking()
                           from dtn in context.Descriptions.AsNoTracking()
                           from id in descriptors
                           where code.Descriptor.Equals(id.Id) && dtn.Id.Equals(id.Id)
                           select new ReadUpdateDTO(code, id, dtn);
            return await codes.ToListAsync();
        }

        /// <summary>
        /// Get all available codes from the Dabatase with the given Tech or a partly match
        /// </summary>
        /// <param name="lang">The Tech Property of the Descriptor</param>
        /// <returns>A List of all codes in the given tech</returns>
        public async Task<IEnumerable<ReadUpdateDTO>> GetByTechAsync(string tech)
        {
            var descriptors = context.Descriptors.AsNoTracking().Where(c => c.Tech.Contains(tech) || tech.Contains(c.Tech));
            var codes = from code in context.Codes.AsNoTracking()
                           from dtn in context.Descriptions.AsNoTracking()
                           from id in descriptors
                           where code.Descriptor.Equals(id.Id) && dtn.Id.Equals(id.Id)
                           select new ReadUpdateDTO(code, id, dtn);
            return await codes.ToListAsync();
        }

        //-----------------------------
        //--------- UPDATE -----------
        //-----------------------------
        /// <summary>
        /// Update the code/Descriptor/Description matching the ReadUpdateDTO
        /// </summary>
        /// <param name="code">ReadUpdateDTO to update</param>
        /// <returns>a ServiceResponse with an Error and an empty Guid on Error or with the Guid of the 
        ///         updated code/Descriptor/Description on success </returns>
        public async Task<ServiceResponse<Guid>> UpdateAsync(ReadUpdateDTO dto)
        {
            var code = KBCode.fromDTO(dto);
            var dtr = KBDescriptor.fromDTO(dto);
            var dtn = KBDescription.fromDTO(dto);
            var code_res = context.Codes.Update(code);
            var dtr_res = context.Descriptors.Update(dtr);
            var dtn_res = context.Descriptions.Update(dtn);

            if (code_res is null || dtr_res is null || dtn_res is null)
            {
                return new ServiceResponse<Guid>(true, "Error Updating code", Guid.Empty);
            }
            else
            {
                await SaveChangesAsync();
                return new ServiceResponse<Guid>(false, "code Updated", dto.Id);
            }
        }

        //-----------------------------
        //--------- DELETE ------------
        //-----------------------------
        /// <summary>
        /// Deletes the code/Descriptor/Description with the given id
        /// </summary>
        /// <param name="id">The Guid of the Descriptor connecting the code/Descriptor/Description</param>
        /// <returns>a ServiceResponse with an Error and an empty Guid on Error or with the deleted id on success</returns>
        public async Task<ServiceResponse<Guid>> DeleteAsync(Guid id)
        {
            var code = await context.Codes.FindAsync(id);
            var dtr = await context.Descriptors.FindAsync(id);
            var dtn = await context.Descriptions.FindAsync(id);

            if (code is null || dtr is null || dtn is null)
            {
                return new ServiceResponse<Guid>(true, $"Could not delete {id}", Guid.Empty);
            }
            else
            {
                context.Codes.Remove(code);
                context.Descriptors.Remove(dtr);
                context.Descriptions.Remove(dtn);
                await SaveChangesAsync();
                return new ServiceResponse<Guid>(false, "code successfully deleted", id);
            }
        }

        //-----------------------------
        //--------- VALIDATION --------
        //-----------------------------
        public async Task<bool> IsUniqueCode(CreateDTO code)
        {
            return !await context.Codes.AnyAsync(c => c.Code.Equals(code.Text));
        }
        public Task<bool> HasRequiredData(CreateDTO code)
        {
            return Task.FromResult(!string.IsNullOrEmpty(code.Text));
        }
        public async Task<bool> HasValidExistingId(ReadUpdateDTO code)
        {
            var there = !string.IsNullOrEmpty(code.Id.ToString());
            var exists = await context.Codes.AnyAsync(c => c.Descriptor.Equals(code.Id));

            return await Task.FromResult(there && exists);
        }
        public async Task<bool> IsExistingId(Guid id)
        {
            return await context.Codes.AnyAsync(c => c.Descriptor.Equals(id));
        }

        //-----------------------------
        //--------- SAVE CHANGES ------
        //-----------------------------
        /// <summary>
        /// Saves the Changes to the Database
        /// </summary>
        /// <returns></returns>
        private async Task SaveChangesAsync() => await context.SaveChangesAsync();
    }
}
