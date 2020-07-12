using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Services;
using Common.Commands;
using IdentityServer4.Extensions;
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
        private readonly IUserService userService;

        public UsersController(IBusClient busClient, IUserService userService)
        {
            this.busClient = busClient;
            this.userService = userService;
        }

        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "standard")]
        [ProducesResponseType(403)]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await userService.GetAllAsync();
            //test what this does after doing the migration
            var testClaims = User;
            var test = User.Identity.GetSubjectId();
            return Ok(users);
        }

        [HttpPost("RegisterUser")]
        [ProducesResponseType(202)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> RegisterUser([FromBody] CreateUser createUser)
        {
            var emailTaken = await userService.EmailTakenAsync(createUser.Email);
            if (emailTaken) return BadRequest("Email already taken");

            await busClient.PublishAsync(createUser);
            return Accepted($"RegisterUser/{createUser.Email}");
        }
    }
}