using Api.Domain.Models;
using Api.Domain.Services;
using Common.Events;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Handlers
{
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        private readonly IUserService service;
        public UserCreatedHandler(IUserService service)
        {
            this.service = service;
        }
        public async Task HandleAsync(UserCreated @event)
        {
            await service.AddUserAsync(new User { Email = @event.Email, Name = @event.Name, 
                UserName = @event.UserName, LastActive = @event.LastActive });
        }
    }
}
