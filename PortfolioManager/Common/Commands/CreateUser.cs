using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Commands
{
    /// <summary>
    /// <para>Message for the service bus to create the user.</para>
    /// <para>Extends the <c>ICommand</c> interface. </para>
    /// </summary>
    public class CreateUser : ICommand
    {
        /// <summary>
        /// Represents the user's name.
        /// </summary>
        /// <value> gets/sets the user's name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Represents the user's last name.
        /// </summary>
        /// <value> gets/sets the user's last name. </value>
        public string LastName { get; set; }
        /// <summary> Represents the user's email. </summary>
        /// <value> gets/sets the user's email. </value>
        public string Email { get; set; }
        /// <summary> Represents the user's password. </summary>
        /// <value> gets/sets the un-encrypted user's password </value>
        public string Password { get; set; }
        /// <summary> 
        /// Represents the User creation time. This is only usefull when its and organization account.
        /// </summary>
        /// <value> gets/sets at what time the user was created. </value>
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary> 
        /// Represents who created the user. This is only usefull when its and organization account.
        /// </summary>
        /// <value> gets/sets the admin that created the user. </value>
        public string CreatedBy { get; set; }
    }
}
