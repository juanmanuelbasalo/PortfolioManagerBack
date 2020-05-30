using System;
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
    public class UsersController : ControllerBase
    {
        private readonly IBusClient busClient;

        public UsersController(IBusClient busClient)
        {
            this.busClient = busClient;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [HttpPost("RegisterUser")]
        [ProducesResponseType(202)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> RegisterUser([FromBody] CreateUser createUser)
        {
            await busClient.PublishAsync(createUser);
            return Accepted();
        }
    }
}