using AutoMapper;
using Common.Commands;
using Common.Events;
using Common.Exceptions;
using Identity.Domain.Models;
using Identity.Domain.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Handlers
{
    /// <summary>
    /// Extends the ICommandHandler interface to create specific handler.
    /// </summary>
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient busClient;
        private readonly ILogger<CreateUserHandler> logger;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public CreateUserHandler(IBusClient busClient, ILogger<CreateUserHandler> logger,
                                 IMapper mapper, IUserService userService)
        {
            this.busClient = busClient;
            this.logger = logger;
            this.mapper = mapper;
            this.userService = userService;
        }
        /// <summary>
        /// Specific Handler for my <c>CreateUser</c> Command.
        /// </summary>
        /// <param name="command">CreateUser command to handle.</param>
        /// <returns>Empty Task</returns>
        public async Task HandleAsync(CreateUser command)
        {
            try
            {
                logger.LogInformation($"Creating user: {command.Name}.");

                var user = mapper.Map<UserRegister>(command);
                var userRegistered = await userService.RegisterAsync(user);

                if (userRegistered == null) await busClient.PublishAsync(new CreateUserRejected(command.Email,
                                                                         "The email is already in use", "400"));
                else
                    await busClient.PublishAsync(new UserCreated(userRegistered.Email, userRegistered.Name));

            }
            catch (CustomException ex)
            {
                await busClient.PublishAsync(new CreateUserRejected(command.Email, "Problem saving user.", ex.Code));
                logger.LogError(ex.Message);
            }
        }
    }
}
