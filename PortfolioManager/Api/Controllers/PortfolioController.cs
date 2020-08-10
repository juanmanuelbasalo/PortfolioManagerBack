using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiScope")]
    public class PortfolioController : ControllerBase
    {
        private readonly IBusClient busClient;

        public PortfolioController(IBusClient busClient)
        {
            this.busClient = busClient;
        }

        [HttpPost]
        [Authorize(Roles = "Standard")]
        [ProducesResponseType(202)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> CreatePortfolio([FromBody] CreatePortfolio createPortfolio)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); //retuns the userId
            createPortfolio.UserId = Guid.Parse(userId);
            createPortfolio.PortfolioId = Guid.NewGuid();
            await busClient.PublishAsync(createPortfolio);
            return Accepted($"CreatePortfolio/{createPortfolio.PortfolioId}");
        }

        [HttpPost]
        [Authorize(Roles = "Standard")]
        [ProducesResponseType(202)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> BuySecurities([FromBody] BuySecurity security)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); //retuns the userId
            security.UserId = Guid.Parse(userId);
            security.SecurityId = Guid.NewGuid();
            await busClient.PublishAsync(security);
            return Accepted($"BuySecurities/{security.SecurityId}");
        }
    }
}