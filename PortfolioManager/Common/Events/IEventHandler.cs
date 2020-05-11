using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Events
{
    /// <summary>
    /// Interface used to implement specific event handlers. 
    /// </summary>
    /// <typeparam name="TEvent"> Specific event type. </typeparam>
    public interface IEventHandler<in TEvent> where TEvent : IEvent 
    {
        /// <summary>
        /// Contract about the event we are expecting.
        /// </summary>
        /// <param name="event"> The specific event.</param>
        /// <returns>Empty Task.</returns>
        Task HandleAsync(TEvent @event);
    }
}
