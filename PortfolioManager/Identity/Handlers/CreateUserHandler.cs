using Common.Commands;
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
        /// <summary>
        /// Specific Handler for my <c>CreateUser</c> Command.
        /// </summary>
        /// <param name="command">CreateUser command to handle.</param>
        /// <returns>Empty Task</returns>
        public Task HandleAsync(CreateUser command)
        {
            throw new NotImplementedException();
        }
    }
}
