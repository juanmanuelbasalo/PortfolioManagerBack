﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    [Authorize]
    public class PortfolioController : ControllerBase
    {
        private readonly IBusClient busClient;

        public PortfolioController(IBusClient busClient)
        {
            this.busClient = busClient;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        public async Task<ActionResult> CreatePortfolio([FromBody] CreatePortfolio createPortfolio)
        {
            createPortfolio.UserName = User.Identity.Name;
            await busClient.PublishAsync(createPortfolio);
            return Accepted($"CreatePortfolio/{createPortfolio.PortfolioId}");
        }
    }
}