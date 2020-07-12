using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Data_Access.Entities
{
    /// <summary>
    /// The User entity. Each property represents the columns from the table.
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Id.
        /// </summary>
        public Guid Id { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// Name of the user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User's last name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// User's email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Encrypted user's password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// To create role base authentication with ids4
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// Date and time of user's creation.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>
        /// Who created the user. The system by default.
        /// </summary>
        public string CreatedBy { get; set; }
        public DateTimeOffset LastActive { get; set; }
    }
}
