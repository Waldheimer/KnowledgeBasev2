using KnowledgeBasev2.Infrastructure.ContractImplementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBasev2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly DefaultInfoRepo repo;

        public InfoController(DefaultInfoRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet("systems")]
        public IEnumerable<string> GetAllSystems()
        {
            return repo.GetSystems();
        }
        [HttpGet("techs")]
        public IEnumerable<string> GetAllTechs() 
        { 
            return repo.GetTechs();
        }
        [HttpGet("langs")]
        public IEnumerable<string> GetAllLangs()
        {
            return repo.GetLangs();
        }
    }
}
