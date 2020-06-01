﻿using Identity.HelperMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class UserRegister
    {
        public Guid Id { get; set; } = Guid.NewGuid();
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
        public string Role { get; set; }
        /// <summary>
        /// Encrypted user's password.
        /// </summary>
        public string Password { get => password; set => password = SecurePasswordHasher.Hash(value); }
        /// <summary>
        /// Date and time of user's creation.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        /// <summary>
        /// Who created the user. The system by default.
        /// </summary>
        public string CreatedBy { get; set; }
        private string password;
    }
}
