using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Commands
{
    /// <summary> Interface to be implemented by the specific command handlers. </summary>
    /// <typeparam name="TCommand"> The generic command we are going to process. </typeparam>
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Contract about what we are going to handle.
        /// </summary>
        /// <param name="command"> The generic command we are going to handle. </param>
        /// <returns> Empty Task </returns>
        Task HandleAsync(TCommand command); 
    }
}
