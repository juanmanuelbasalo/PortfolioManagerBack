using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Commands
{
    /// <summary>
    /// <para>Message for the service bus to authenticate a user.</para>
    /// <para>Extends the <c>ICommand</c> interface. </para>
    /// </summary>
    public class AuthenticateUser : ICommand
    {
        /// <summary> Represents the user's email. </summary>
        /// <value> gets/sets the email that will be used to check if exists. </value>
        public string Email { get; set; }
        /// <summary> Represents the user´s password. </summary>
        /// <value> gets/sets user password to check if its the user's password. </value>
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
    }
}
