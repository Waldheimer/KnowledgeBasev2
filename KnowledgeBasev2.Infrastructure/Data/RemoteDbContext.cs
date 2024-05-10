using KnowledgeBasev2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBasev2.Infrastructure.Data
{
    public class RemoteDbContext : DbContext
    {
        public RemoteDbContext(DbContextOptions<RemoteDbContext> options) : base(options)
        {
        }

        public DbSet<KBCommand> Commands { get; set; }
        public DbSet<KBCode> Codes { get; set; }
        public DbSet<KBDocumentation> Documentations { get; set; }
        public DbSet<KBDescriptor> Descriptors { get; set; }
        public DbSet<KBDescription> Descriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("kb");

            base.OnModelCreating(modelBuilder);
        }
    }
}
