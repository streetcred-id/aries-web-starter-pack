using System.Threading.Tasks;
using AgentFramework.Core.Contracts;
using AgentFramework.Core.Handlers.Agents;
using AgentFramework.Core.Models.Records;
using Microsoft.AspNetCore.Mvc;

namespace WebAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAgentProvider agentProvider;
        private readonly IProvisioningService provisioningService;

        public HomeController(IAgentProvider agentProvider, IProvisioningService provisioningService)
        {
            this.agentProvider = agentProvider;
            this.provisioningService = provisioningService;
        }

        // GET api/home
        [HttpGet]
        public async Task<ProvisioningRecord> Get()
        {
            var agentContext = await agentProvider.GetContextAsync();
            var record = await provisioningService.GetProvisioningAsync(agentContext.Wallet);

            return record;
        }
    }
}
