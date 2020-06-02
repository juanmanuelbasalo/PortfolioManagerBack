using Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Handlers
{
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        public UserCreatedHandler()
        {

        }
        public Task HandleAsync(UserCreated @event)
        {
            throw new NotImplementedException();
        }
    }
}
