using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Commands
{
    /// <summary>
    /// <para>Message for the service bus to create the user.</para>
    /// <para>Extends the <c>ICommand</c> interface. </para>
    /// </summary>
    public class CreateUser : ICommand
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Represents the user's name.
        /// </summary>
        /// <value> gets/sets the user's name.</value>
        [Required(ErrorMessage = "Insert your name")]
        public string Name { get; set; }
        /// <summary>
        /// Represents the user's last name.
        /// </summary>
        /// <value> gets/sets the user's last name. </value>
        [Required(ErrorMessage = "Insert your lastname")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please add your user name")]
        public string UserName { get; set; }
        /// <summary> Represents the user's email. </summary>
        /// <value> gets/sets the user's email. </value>
        [Required(ErrorMessage = "Mandatory field")]
        [EmailAddress(ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }
        /// <summary> Represents the user's password. </summary>
        /// <value> gets/sets the un-encrypted user's password </value>
        [Required(ErrorMessage = "Password is needed")]
        [MinLength(8, ErrorMessage = "Must be at least 8 characters.")]
        public string Password { get; set; }
        public string Role { get; set; }
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
        public DateTimeOffset LastActive { get; set; }
    }
}
