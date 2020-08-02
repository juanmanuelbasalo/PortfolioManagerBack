using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    /// <summary>
    /// Event for when the user is autheticated
    /// </summary>
    public interface IAuthenticatedEvent : IEvent
    {
        /// <summary>
        /// Readonly property to get the user id.
        /// </summary>
        Guid UserId { get; }
    }
}
