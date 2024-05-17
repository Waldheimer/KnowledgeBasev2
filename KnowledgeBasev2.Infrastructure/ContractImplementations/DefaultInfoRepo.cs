using KnowledgeBasev2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBasev2.Infrastructure.ContractImplementations
{
    public class DefaultInfoRepo
    {
        private readonly RemoteDbContext context;

        public DefaultInfoRepo(RemoteDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<string> GetSystems()
        {
            return context.Database.SqlQuery<string>($"SELECT * FROM Systems");
        }
        public IEnumerable<string> GetTechs()
        {
            return context.Database.SqlQuery<string>($"SELECT * FROM Technologies");
        }
        public IEnumerable<string> GetLangs()
        {
            return context.Database.SqlQuery<string>($"SELECT * FROM Languages");
        }
    }
}
