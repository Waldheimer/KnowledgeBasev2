using KnowledgeBasev2.Application.Contracts;
using KnowledgeBasev2.Application.DTOs;
using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.Domain.Entities;
using KnowledgeBasev2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBasev2.Infrastructure.ContractImplementations
{
    public class KBDocumentationRepo : IKbDocumentation
    {
        private readonly RemoteDbContext context;

        public KBDocumentationRepo(RemoteDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Create a new documentation from a CreateDTO including Descriptor and Description and save them to the Database
        /// </summary>
        /// <param name="documentation">The CreateDTO contains all required Information to create a new documentation except the Guid</param>
        /// <returns>a ServiceResponse with an empty Guid if failed or the new Guid if successful</returns>
        public async Task<ServiceResponse<Guid>> CreateAsync(CreateDTO dto)
        {
            Guid guid = Guid.NewGuid();
            var doc = context.Documentations.Add(KBDocumentation.fromDTO(dto, guid));
            var dtr = context.Descriptors.Add(KBDescriptor.fromDTO(dto, guid));
            var dtn = context.Descriptions.Add(KBDescription.fromDTO(dto, guid));
            if (doc is null || dtr is null || dtn is null)
            {
                return new ServiceResponse<Guid>(true, "Something went wrong while saving the data", Guid.Empty);
            }
            else
            {
                await SaveChangesAsync();
                return new ServiceResponse<Guid>(false, "New Documentation successfully created", guid);
            }
        }


        /// <summary>
        /// Get all available documentations from the Database and returns them as ReadUpdateDTO
        /// including the data from the descriptor and description
        /// </summary>
        /// <returns>A List of documentations as ReadUpdateDTOs</returns>
        public async Task<IEnumerable<ReadUpdateDTO>> GetAsync()
        {
            var result = from documentation in context.Documentations.AsNoTracking()
                         from descriptor in context.Descriptors.AsNoTracking()
                         from description in context.Descriptions.AsNoTracking()
                         where descriptor.Id.Equals(documentation.Descriptor) && description.Id.Equals(documentation.Descriptor)
                         select new ReadUpdateDTO(documentation, descriptor, description);
            return await result.ToListAsync();
        }

        /// <summary>
        /// Gets the Documentation/Descriptor/Description with the given Id from the Database and combines the data into a single ReadUpdateDTO
        /// </summary>
        /// <param name="id">The Guid of the Descriptor connection documentation/Descriptor/Description</param>
        /// <returns>A single ReadUpdateDTO with the given id</returns>
        public async Task<ReadUpdateDTO> GetByIdAsync(Guid id)
        {
            var documentation = await context.Documentations.FirstAsync(c => c.Descriptor.Equals(id));
            var dct = await context.Descriptors.FirstAsync(d => d.Id.Equals(id));
            var dtn = await context.Descriptions.FirstAsync(d => d.Id.Equals(id));
            if (documentation is null || dct is null || dtn is null)
            {
                return ReadUpdateDTO.Default;
            }
            else
            {
                return new ReadUpdateDTO(documentation, dct, dtn);
            }
        }

        /// <summary>
        /// Get all available documentations from the Dabatase with the given "Lang"uage or a partly match
        /// </summary>
        /// <param name="lang">The "Lang"uage Property of the Descriptor</param>
        /// <returns>A List of all documentations in the given lang</returns>
        public async Task<IEnumerable<ReadUpdateDTO>> GetByLangAsync(string lang)
        {
            var descriptors = context.Descriptors.AsNoTracking().Where(c => c.Lang.Contains(lang) || lang.Contains(c.Lang));
            var documentations = from documentation in context.Documentations.AsNoTracking()
                        from dtn in context.Descriptions.AsNoTracking()
                        from id in descriptors
                        where documentation.Descriptor.Equals(id.Id) && dtn.Id.Equals(id.Id)
                        select new ReadUpdateDTO(documentation, id, dtn);
            return await documentations.ToListAsync();
        }

        /// <summary>
        /// Get all available documentations from the Dabatase with the given "System" or a partly match
        /// </summary>
        /// <param name="lang">The System Property of the Descriptor</param>
        /// <returns>A List of all documentations in the given system</returns>
        public async Task<IEnumerable<ReadUpdateDTO>> GetBySystemAsync(string system)
        {
            var descriptors = context.Descriptors.AsNoTracking().Where(c => c.System.Contains(system) || system.Contains(c.System));
            var documentations = from documentation in context.Documentations.AsNoTracking()
                        from dtn in context.Descriptions.AsNoTracking()
                        from id in descriptors
                        where documentation.Descriptor.Equals(id.Id) && dtn.Id.Equals(id.Id)
                        select new ReadUpdateDTO(documentation, id, dtn);
            return await documentations.ToListAsync();
        }

        /// <summary>
        /// Get all available documentations from the Dabatase with the given Tech or a partly match
        /// </summary>
        /// <param name="lang">The Tech Property of the Descriptor</param>
        /// <returns>A List of all documentations in the given tech</returns>
        public async Task<IEnumerable<ReadUpdateDTO>> GetByTechAsync(string tech)
        {
            var descriptors = context.Descriptors.AsNoTracking().Where(c => c.Tech.Contains(tech) || tech.Contains(c.Tech));
            var documentations = from documentation in context.Documentations.AsNoTracking()
                        from dtn in context.Descriptions.AsNoTracking()
                        from id in descriptors
                        where documentation.Descriptor.Equals(id.Id) && dtn.Id.Equals(id.Id)
                        select new ReadUpdateDTO(documentation, id, dtn);
            return await documentations.ToListAsync();
        }


        /// <summary>
        /// Update the documentation/Descriptor/Description matching the ReadUpdateDTO
        /// </summary>
        /// <param name="documentation">ReadUpdateDTO to update</param>
        /// <returns>a ServiceResponse with an Error and an empty Guid on Error or with the Guid of the 
        ///         updated documentation/Descriptor/Description on success </returns>
        public async Task<ServiceResponse<Guid>> UpdateAsync(ReadUpdateDTO dto)
        {
            var documentation = KBDocumentation.fromDTO(dto);
            var dtr = KBDescriptor.fromDTO(dto);
            var dtn = KBDescription.fromDTO(dto);
            var docu_res = context.Documentations.Update(documentation);
            var dtr_res = context.Descriptors.Update(dtr);
            var dtn_res = context.Descriptions.Update(dtn);

            if (docu_res is null || dtr_res is null || dtn_res is null)
            {
                return new ServiceResponse<Guid>(true, "Error Updating documentation", Guid.Empty);
            }
            else
            {
                await SaveChangesAsync();
                return new ServiceResponse<Guid>(false, "documentation Updated", documentation.Descriptor);
            }
        }


        /// <summary>
        /// Deletes the documentation/Descriptor/Description with the given id
        /// </summary>
        /// <param name="id">The Guid of the Descriptor connecting the documentation/Descriptor/Description</param>
        /// <returns>a ServiceResponse with an Error and an empty Guid on Error or with the deleted id on success</returns>
        public async Task<ServiceResponse<Guid>> DeleteAsync(Guid id)
        {
            var documentation = await context.Documentations.FindAsync(id);
            var dtr = await context.Descriptors.FindAsync(id);
            var dtn = await context.Descriptions.FindAsync(id);

            if (documentation is null || dtr is null || dtn is null)
            {
                return new ServiceResponse<Guid>(true, $"Could not delete {id}", Guid.Empty);
            }
            else
            {
                context.Documentations.Remove(documentation);
                context.Descriptors.Remove(dtr);
                context.Descriptions.Remove(dtn);
                await SaveChangesAsync();
                return new ServiceResponse<Guid>(false, "documentation successfully deleted", id);
            }
        }

        /// <summary>
        /// Saves the Changes to the Database
        /// </summary>
        /// <returns></returns>
        private async Task SaveChangesAsync() => await context.SaveChangesAsync();
    }
}
