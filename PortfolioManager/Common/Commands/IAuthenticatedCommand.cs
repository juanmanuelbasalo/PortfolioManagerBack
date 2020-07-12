using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Commands
{
    /// <summary>
    /// <para>Marker interface for commands that need to have a user authenticated.</para>
    /// <para>It implements ICommand.</para>
    /// </summary>
    public interface IAuthenticatedCommand : ICommand
    {
        /// <summary>
        /// <para>Property that contains the user Id.</para>
        /// </summary>
        /// <returns>Returns the current User Id.</returns>
        string UserName { get; set; }
    }
}
